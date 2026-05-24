
using System;
using UnityEngine;

public interface IScoreService
{
    public void StartRun();
    public void StopRun();
    public void ResetScore();

    public event Action<int> OnScoreChanged;
}
