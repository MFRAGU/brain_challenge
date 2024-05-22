using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class ClientSocketUseCase
{
     private IClient clientSocket;

    public ClientSocketUseCase(IClient clientSocket)
    {
        this.clientSocket = clientSocket;
    }

    public void Connect()
    {
        try
        {
            clientSocket.Connect();
        }
        catch (Exception e)
        {
            Debug.LogError("Connect Use Case failed: " + e.Message);
        }
    }

    public void Disconnect()
    {
        try
        {
            clientSocket.Disconnect();
        }
        catch (Exception e)
        {
            Debug.LogError("Disconnect Use Case failed: " + e.Message);
        }
    }

    public string SendMessage(string message)
    {
        try
        {
            return clientSocket.SendMessage(message);
        }
        catch (Exception e)
        {
            Debug.LogError("SendMessage Use Case failed: " + e.Message);
            return "Erreur lors de l'envoi du message";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
