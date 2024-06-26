
[System.Serializable]
public class QuestionRequest : Request
{
    public string data;

    public QuestionRequest(Type type, QuestionRequestAction action, string data = null): base(type, action.ToString())
    {
        this.data = data;
    }
}
