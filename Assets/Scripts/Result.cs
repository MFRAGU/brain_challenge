using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Result<T>
{
  protected string name;
  protected T data;
  
  protected Result(string name, T data)
    {
        this.name = name;
        this.data = data;
    }

     public T getData 
    {
        get { return data; }
    }
}
