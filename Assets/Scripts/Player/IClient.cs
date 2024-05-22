using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public interface IClient 
{
    void Connect();
    void Disconnect();
    string SendMessage(string message);

}

