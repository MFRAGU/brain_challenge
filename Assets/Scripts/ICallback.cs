
public interface ICallback<T>
{
    public void OnSuccess(T data);
    public void OnError(string message);
}
