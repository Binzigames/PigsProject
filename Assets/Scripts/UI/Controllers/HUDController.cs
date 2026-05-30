using UnityEngine;
using Zenject;

public class HUDController : MonoBehaviour
{
    private GameManager _gameManager;
    private ICurrencyManager _currencyManager;
    private IScoreManager _scoreManager;

    [Inject]
    public void Costruct(GameManager gameManager, ICurrencyManager currencyManager, IScoreManager scoreManager)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
        _scoreManager = scoreManager;
    }

    private void OnEnable()
    {
        HUDEvents.OnPausePressed += PauseGame;

        _currencyManager.OnCollectedCurrency += HandleCurrencyLabel;
        _scoreManager.OnScoreChanged += HandleScoreLabel;
    }

    private void OnDisable()
    {
        HUDEvents.OnPausePressed -= PauseGame;

        _currencyManager.OnCollectedCurrency -= HandleCurrencyLabel;
        _scoreManager.OnScoreChanged -= HandleScoreLabel;
    }

    private void HandleCurrencyLabel(int value)
    {
        HUDEvents.OnChangedCurrency?.Invoke(value);
    }

    private void HandleScoreLabel(int score)
    {
        HUDEvents.OnChangedScore?.Invoke(score);
    }

    private void PauseGame()
    {
        var pauseCommand = new PauseGameCommand(_gameManager);
        pauseCommand.Execute();
    }
}
