using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Callback<T> 
{
   public void OnSuccess(T data);
   public void OnError(string message);
}
