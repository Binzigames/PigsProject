using DevConfigs.GameStateMachine;
using Scripts.UI.Events;
using UnityEngine;
using Zenject;

public class ResultController : MonoBehaviour
{
    private GameManager _gameManager;
    private ICurrencyManager _currencyManager;
    private IScoreManager _scoreManager;

    [Inject]
    public void Construct(GameManager gameManager, ICurrencyManager currencyManager, IScoreManager scoreManager)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
        _scoreManager = scoreManager;
    }

    private void OnEnable()
    {
        _gameManager.GameStateMachine.OnChangeState += SummurizeResults;

        ResultScreenEvents.OnContinueButtonPressed += ContinueGame;
    }

    private void OnDisable()
    {
        _gameManager.GameStateMachine.OnChangeState += SummurizeResults;
        
        ResultScreenEvents.OnContinueButtonPressed -= ContinueGame;
    }

    private void SummurizeResults(IGameState gameState)
    {
        if (gameState is ResultGameState)
        {
            SummarizeScore();
            SummarizeCurrency();
        }
    }

    private void SummarizeScore()
    {
        var scoreReached = _scoreManager.CurrentScore;
        ResultScreenEvents.OnScoreResult?.Invoke(scoreReached);

        var bestRecord = _gameManager.SaveData.BestScore;
        ResultScreenEvents.OnShowBestScore?.Invoke(bestRecord);
    }

    private void SummarizeCurrency()
    {
        var collectedMoney = _currencyManager.TotalCurrency;
        ResultScreenEvents.OnCurrencyResult?.Invoke(collectedMoney);
    }

    private void ContinueGame()
    {
        var menuCommand = new MenuGameCommand(_gameManager);
        menuCommand.Execute();
    }
}
