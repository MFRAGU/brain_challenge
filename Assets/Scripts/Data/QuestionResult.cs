using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionResult 
{
    public string name {private set; get;}
    public List<Question> data {private set; get;}

    public QuestionResult(string name, List<Question> data){
        this.name = name;
        this.data = data;
    }
    
}
