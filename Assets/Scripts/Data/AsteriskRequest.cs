using UnityEngine;

[System.Serializable]
public class AsteriskRequest: Request
{
    public AsteriskRequest(Type type, AsteriskAction action): base(type, action.ToString()){ }
   
}
