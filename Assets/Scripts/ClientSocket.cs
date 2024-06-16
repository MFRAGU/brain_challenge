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

    private readonly string serverIP; 
    private readonly int port; 

    public ClientSocket(string serverIP, int port)
    {
        this.serverIP = serverIP;
        this.port = port;
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
            Debug.LogError("Connection failed: " + e.Message);
            throw new Exception("Connection failed: " + e.Message);
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
            Debug.LogError("Disconnection failed: " + e.Message);
        }
    }

    public Result<T> SendMessage<T>(Request requete)
    {
         try
        {
            string jsonRequest = JsonUtility.ToJson(requete);
            writer.WriteLine(jsonRequest);
            string jsonResponse = reader.ReadLine();
            Result<T> result = JsonUtility.FromJson<Result<T>>(jsonResponse);

            return result;
        }
        catch (Exception e)
        {
            Debug.LogError("SendMessage failed: " + e.Message);
            throw new Exception("SendMessage failed: " + e.Message);
        }
    }

    public Result<T> RecupMessage<T>()
    {
        try
        {
            string jsonResponse = reader.ReadLine();
            Result<T> result = JsonUtility.FromJson<Result<T>>(jsonResponse);

            return result;
        }
        catch (Exception e)
        {
            Debug.LogError("RecupMessage failed: " + e.Message);
            throw new Exception("RecupMessage failed: " + e.Message);
        }
        
    }
}
