using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataResults", menuName = "ScriptableObjects/ResultsScriptableObject")]
public class ResultsScriptableObject : ScriptableObject
{
    public Dictionary<Question, string> results = new Dictionary<Question, string>();

    public Dictionary<Question, string> GetResults()
    {
        return results;
    }

    public void AddResult(Question question, string response)
    {
        if (!results.ContainsKey(question))
        {
            results.Add(question, response);
        }
        else
        {
            results[question] = response;
        }
    }

    public void ClearResults()
    {
        results.Clear();
    }
}
