using UnityEngine;
using Zenject;

public class HUDController : MonoBehaviour
{
    private GameManager _gameManager;
    private CurrencyManager _currencyManager;
    private IScoreService _scoreService;

    [Inject]
    public void Costruct(GameManager gameManager, CurrencyManager currencyManager, IScoreService scoreService)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
        _scoreService = scoreService;
    }

    private void OnEnable()
    {
        HUDEvents.OnPausePressed += PauseGame;

        _currencyManager.OnCollectedCurrency += HandleCurrencyLabel;
        _scoreService.OnScoreChanged += HandleScoreLabel;
    }

    private void OnDisable()
    {
        HUDEvents.OnPausePressed -= PauseGame;

        _currencyManager.OnCollectedCurrency -= HandleCurrencyLabel;
        _scoreService.OnScoreChanged -= HandleScoreLabel;
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
