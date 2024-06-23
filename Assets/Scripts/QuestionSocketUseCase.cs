using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

public class QuestionSocketUseCase 
{
    private ClientSocket clientSocket;
    private Callback <QuestionResult> callBack; 

    public QuestionSocketUseCase(ClientSocket clientSocket)
    {
        this.clientSocket = clientSocket;
    }

    public void SendRandomQuestionRequest()
    {
        try
        {
            QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.RANDOM);
            string response = clientSocket.SendMessage(request);
            ParseResult(response);
        }
        catch (Exception e)
        {
            Debug.LogError("SendRandomQuestionRequest failed: " + e.Message);
            throw new Exception("SendRandomQuestionRequest failed: " + e.Message);
        }
    }

    public void SendDifficultyQuestionRequest(DifficultyLevel difficultyLevel)
    {
        try
        {
            QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.DIFFICULTY, difficultyLevel.ToString());
            string response = clientSocket.SendMessage(request);
            ParseResult(response);
        }
        catch (Exception e)
        {
            Debug.LogError("SendDifficultyQuestionRequest failed: " + e.Message);
            throw new Exception("SendDifficultyQuestionRequest failed: " + e.Message);
        }
    }

    private void ParseResult(string result){
        try{
            JsonUtility.FromJson<QuestionResult>(result);
            QuestionResult resultJson = JsonUtility.FromJson<QuestionResult>(result);
            callBack.OnSuccess(resultJson);
        }catch (Exception e)
        {
            callBack.OnError(e.Message);
        }
        
    }
   
}
