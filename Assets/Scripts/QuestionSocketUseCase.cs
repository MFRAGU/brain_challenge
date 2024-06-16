using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

public class QuestionSocketUseCase 
{

     private ClientSocket clientSocket;

    public QuestionSocketUseCase(ClientSocket clientSocket)
    {
        this.clientSocket = clientSocket;
    }

    public QuestionResult SendRandomQuestionRequest()
    {
        try
        {
            QuestionRequest request = new QuestionRequest();
            Result<QuestionResult> result = clientSocket.SendMessage<QuestionResult>(request);

            return result.getData;
        }
        catch (Exception e)
        {
            Debug.LogError("SendRandomQuestionRequest failed: " + e.Message);
            throw new Exception("SendRandomQuestionRequest failed: " + e.Message);
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
