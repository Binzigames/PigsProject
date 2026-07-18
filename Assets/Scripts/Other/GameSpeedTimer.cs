using System;

public class GameSpeedTimer
{

    public GameSpeedTimer(int interval)
    {
        _interval = interval;
    }

    private readonly float _interval;
    private float _elapsedTime;

    public event Action OnTimeReached;

    public void Tick(float deltaTime)
    {
        _elapsedTime += deltaTime;

        if (_elapsedTime < _interval)
            return;

        _elapsedTime = 0f;
        OnTimeReached?.Invoke();
    }

}
