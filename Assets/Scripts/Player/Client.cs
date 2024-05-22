using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;

public class Client : MonoBehaviour, IClient
{

    private TcpClient client;
    private StreamReader reader;
    private StreamWriter writer;

    private string serverIP = "127.0.0.1"; 
    private int port = 12345; 

    public Client(string serverIP, int port)
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

    public string SendMessage(string message)
    {
        try
        {
            writer.WriteLine(message);
            Debug.Log("Sent to server: " + message);
            string response = reader.ReadLine();
            Debug.Log("Received from server: " + response);
            return response;
        }
        catch (Exception e)
        {
            Debug.LogError("Send message failed: " + e.Message);
            throw new Exception("Send message failed: " + e.Message);
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
}
