using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ClientSocketTest : MonoBehaviour
{
    private ClientSocketUseCase clientSocketUseCase;
    public Text errorMessageText; // Ajout de la variable pour le composant UI Text

    void Start()
    {
        IClient clientSocket = new Client("127.0.0.1", 12345);
        clientSocketUseCase = new ClientSocketUseCase(clientSocket);

        try
        {
            // Tenter de se connecter au serveur
            clientSocketUseCase.Connect();

            // Envoyer un message au serveur
            string response = clientSocketUseCase.SendMessage("Hello, server!");
            Debug.Log("Response from server: " + response);

            // Déconnexion
            clientSocketUseCase.Disconnect();
        }
        catch (Exception e)
        {
            HandleErrorMessage(e.Message);
        }
    }

    // Méthode pour gérer les messages d'erreur
    private void HandleErrorMessage(string message)
    {
        if (errorMessageText != null)
        {
            errorMessageText.text = message;
        }
        else
        {
            Debug.LogError("Error: " + message);
        }
    }

   
    void Update()
    {
        
    }
}
