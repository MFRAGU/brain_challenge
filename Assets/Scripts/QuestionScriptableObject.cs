using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataQuestions", menuName = "ScriptableObjects/QuestionScriptableObject")]
public class QuestionScriptableObject : ScriptableObject
{
    public List<Question> questions  = new();
   
}
