using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Request 
{
   protected string action;
  protected string type;
    
  protected Request(string action, string type)
    {
        this.action= action;
        this.type = type;
    }
}
