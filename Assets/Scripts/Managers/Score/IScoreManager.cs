using System;

public interface IScoreManager
{
    public int CurrentScore { get; }
    public int Multiplier { get; set; }

    public void StartRun();
    public void StopRun();
    public void ResetScore();

    public event Action<int> OnScoreChanged;
}
