using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteriskResult 
{
    public string name;
    public string data;

    public AsteriskResult(string name, string data) 
    { 
        this.name = name;
        this.data = data;
    } 
}
