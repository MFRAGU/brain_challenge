using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataResults", menuName = "ScriptableObjects/ResultScriptableObject")]
public class ResultScriptableObject : ScriptableObject
{
    private readonly Dictionary<Question, string> _results = new();
    //l'historique des reponses du joueur 
    public Dictionary<Question, string> GetResults()
    {
        return _results;//stocke tout qst et tout reponse jouer
    }

    public void AddResult(Question question, string response)
    //reponse = reponse utilisateur
    {
        if (!_results.ContainsKey(question))
        {
            _results.Add(question, response);
        }
        else
        {
            _results[question] = response;
        }
        Debug.Log("Result value added, Question: " + question.question + "\nResponse: " + response);
    }


    public void ClearResults()
    {
        _results.Clear();
        Debug.Log("Result values is cleared");
    }
}

