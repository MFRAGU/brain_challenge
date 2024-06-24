using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;



public class ClientSocket
{
    private TcpClient client;
    private StreamReader reader;
    private StreamWriter writer;
    private static ClientSocket _instance;

    private readonly string serverIP = "locahost"; 
    private readonly int port = 1234; 

    private ClientSocket(){}

    public static ClientSocket GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClientSocket();
            }
            return _instance;
        }


     public void Connect()
    {
        try
        {
            client = new TcpClient(serverIP, port);
            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
            Debug.Log("Connected to server");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void Disconnect()
    {
        try
        {
            reader?.Close();
            writer?.Close();
            client?.Close();
            Debug.Log("Disconnected from server");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public string SendMessage(Request requete)
    {
        // try
        //{
            string jsonRequest = JsonUtility.ToJson(requete);
            writer.WriteLine(jsonRequest);
            string jsonResponse = reader.ReadLine();

            return jsonResponse;
       // }
       // catch (Exception e)
       // {
            //Debug.LogError(e);
           // return "Error in sending request";
       // }
    }

   

   
}
