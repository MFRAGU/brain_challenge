using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionRequest : Request
{
    public QuestionRequest(
    Type type,
    QuestionRequestAction action,
    string? data = null
    ) : base(type, action.ToString()){}
}

/*convert type and action to string*/