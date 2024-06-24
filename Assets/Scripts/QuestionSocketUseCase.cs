using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using UnityEngine.UI;

public class QuestionSocketUseCase
{
    private ClientSocket clientSocket = ClientSocket.GetInstance();
    private Callback <QuestionResult> callBack; 

   public void SendRandomQuestionRequest()
    {
        Debug.Log("Envoi de message Random");
        QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.RANDOM);
        string response = clientSocket.SendMessage(request);
        ParseResult(response);
  
    }

   public void SendDifficultyQuestionRequest(DifficultyLevel difficultyLevel)
    {
        Debug.Log("Envoi de message Difficulty");
        QuestionRequest request = new QuestionRequest(Type.QUESTION, QuestionRequestAction.DIFFICULTY, difficultyLevel.ToString());
        string response = clientSocket.SendMessage(request);
        ParseResult(response);
    }

    private void ParseResult(string result){
        try{
            JsonUtility.FromJson<QuestionResult>(result);
            QuestionResult resultJson = JsonUtility.FromJson<QuestionResult>(result);
            callBack.OnSuccess(resultJson);
            Debug.Log("Résultat reçu");
        }catch (Exception e)
        {
            callBack.OnError(e.Message);
            Debug.LogError(e);
        }
    }
}
