using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField]
    private int _currentScore;

    [SerializeField]
    private int _bestScore;

    [SerializeField]
    private int _money;

    public int CurrentScore
    {
        get => _currentScore;
        set => _currentScore = value;
    }

    public int BestScore
    {
        get => _bestScore;
        set => _bestScore = value;
    }

    public int Money
    {
        get => _money;
        set => _money = value;
    }

}
