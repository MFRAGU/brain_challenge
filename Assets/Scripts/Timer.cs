
public class Timer
{
    private bool _isActive = false;
    private float _maxTime;
    public float currentTime { get; private set; }

    public Timer(float maxTime)
    {
        _maxTime = maxTime;
        currentTime = _maxTime;
    }

    public void Decrement()
    {
        if (_isActive)
        {
            currentTime -= 1;
        }
    }

    public void SetActive()
    {
        _isActive = true;
    }

    public void SetInactive()
    {
        _isActive = false;
    }

    public void Reset()
    {
        currentTime = _maxTime;
    }
}
