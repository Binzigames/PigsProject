using System;
using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreManager
{
    private const float SCORE_PER_SECOND = 50f;

    [SerializeField] 
    private int _multiplier = 5;
    private int _currentScore;
    private bool _isRunning = false;
    public event Action<int> OnScoreChanged;

    public int CurrentScore => _currentScore;
    public int Multiplier
    {
        get => _multiplier;
        set => _multiplier = value;
    }

    public void StartRun()
    {
        _isRunning = true;
        StartCoroutine(nameof(DistanceScoreLoop));
    }

    public void StopRun()
    {
        _isRunning = false;
        StopAllCoroutines();
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }

    private IEnumerator DistanceScoreLoop()
    {
        while (_isRunning)
        {
            var score = Mathf.RoundToInt(SCORE_PER_SECOND * Time.deltaTime * _multiplier);
            AddScore(score);
            yield return null;
        }

    }
    
    private void AddScore(int value)
    {
        _currentScore += value;
        OnScoreChanged?.Invoke(_currentScore);
    }

}
