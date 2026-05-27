using System;

public interface IScoreService
{
    public int CurrentScore { get; }

    public void StartRun();
    public void StopRun();
    public void ResetScore();

    public event Action<int> OnScoreChanged;
}
