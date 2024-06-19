using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Request 
{
  protected string action;
  protected Type type;
    
  protected Request(Type type, string action)
    {
        this.action= action;
        this.type = type;
    }
}
