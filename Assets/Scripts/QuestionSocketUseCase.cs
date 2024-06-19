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
            QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.RANDOM);
            string response = clientSocket.SendMessage(request);
            return JsonUtility.FromJson<QuestionResult>(response);
        }
        catch (Exception e)
        {
            Debug.LogError("SendRandomQuestionRequest failed: " + e.Message);
            throw new Exception("SendRandomQuestionRequest failed: " + e.Message);
        }
    }

    public QuestionResult SendDifficultyQuestionRequest(DifficultyLevel difficultyLevel)
    {
        try
        {
            QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.DIFFICULTY, difficultyLevel);
            string response = clientSocket.SendMessage(request);
            return JsonUtility.FromJson<QuestionResult>(response);
        }
        catch (Exception e)
        {
            Debug.LogError("SendDifficultyQuestionRequest failed: " + e.Message);
            throw new Exception("SendDifficultyQuestionRequest failed: " + e.Message);
        }
    }

   
}
