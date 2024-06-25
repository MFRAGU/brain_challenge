
public abstract class Request 
{
    public string action;
    public Type type;
    
    public Request(Type type, string action)
    {
        this.action= action;
        this.type = type;
    }
}
