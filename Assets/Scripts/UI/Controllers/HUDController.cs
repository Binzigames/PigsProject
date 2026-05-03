using UnityEngine;
using Zenject;

public class HUDController : MonoBehaviour
{
    private GameManager _gameManager;
    private CurrencyManager _currencyManager;


    [Inject]
    public void Costruct(GameManager gameManager, CurrencyManager currencyManager)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;   
    }

    private void OnEnable()
    {
        // HUDEvents.OnChangedScore += ChangeScorePanel;
        HUDEvents.OnPausePressed += PauseGame;
        _currencyManager.OnCollectedCurrency += HandleCurrencyLabel;
    }

    private void OnDisable()
    {
        // HUDEvents.OnChangedScore -= ChangeScorePanel;
        HUDEvents.OnPausePressed -= PauseGame;
        _currencyManager.OnCollectedCurrency -= HandleCurrencyLabel;
    }

    private void HandleCurrencyLabel(int value)
    {    
        HUDEvents.OnChangedCurrency?.Invoke(value);
    }

    private void HandleScoreLabel(int score)
    {
        // get score from scoreManager
        // scoreService
        // soundService
    }

    private void PauseGame()
    {
        var pauseCommand = new PauseGameCommand(_gameManager);
        pauseCommand.Execute();
    }
}
