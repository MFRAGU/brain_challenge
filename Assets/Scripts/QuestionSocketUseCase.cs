using Newtonsoft.Json;
using System;
using UnityEngine;

public class QuestionSocketUseCase
{
   private readonly ClientSocket _clientSocket = ClientSocket.GetInstance();

   public void SendRandomQuestionRequest(ICallback<QuestionResult> callback)
   {
        Debug.Log("Sending random question request...");
        QuestionRequest questionRequest = new(Type.QUESTION, QuestionRequestAction.RANDOM);
        string jsonRequest = JsonConvert.SerializeObject(questionRequest);
        string response = _clientSocket.SendMessage(jsonRequest);
        ParseResult(response, callback);
  
   }

   public void SendDifficultyQuestionRequest(Difficulty difficultyLevel, ICallback<QuestionResult> callback)
   {
        Debug.Log("Sending question by difficulty request...");
        QuestionRequest questionRequest = new(Type.QUESTION, QuestionRequestAction.DIFFICULTY, difficultyLevel.ToString());
        string jsonRequest = JsonConvert.SerializeObject(questionRequest);
        string response = _clientSocket.SendMessage(jsonRequest);
        ParseResult(response, callback);
    }

    private void ParseResult(string result, ICallback<QuestionResult> callback)
    {
        try
        {
            QuestionResultDTO questionResultDTO = JsonConvert.DeserializeObject<QuestionResultDTO>(result);
            callback.OnSuccess(questionResultDTO.ToQuestionResult());
            Debug.Log("Get question result sucessful");
        }
        catch (JsonSerializationException e)
        {
            ErrorResult errorResult = JsonUtility.FromJson<ErrorResult>(result);
            callback.OnError(errorResult.message);
            Debug.LogError("Error get question result: " + errorResult.message);
            Debug.LogError(e);
        }
        catch (Exception ex)
        {
            callback.OnError("Unexpected error: " + ex.Message);
            Debug.LogError("Unexpected error: " + ex.Message);
            Debug.LogError(ex);
        }
    }
}
