using Newtonsoft.Json;
using UnityEngine;

public class AsteriskRequestUseCase
{
    private readonly ClientSocket _clientSocket = ClientSocket.GetInstance();

    public void SendCallRequest()
    {
        Debug.Log("Sending call request...");
        AsteriskRequest asteriskRequest = new(Type.ASTERISK, AsteriskAction.CALL);
        string jsonRequest = JsonConvert.SerializeObject(asteriskRequest);
        string response = _clientSocket.SendMessage(jsonRequest);
        AsteriskResult result = JsonConvert.DeserializeObject<AsteriskResult>(response);
        Debug.Log(result.data);
    }
}
