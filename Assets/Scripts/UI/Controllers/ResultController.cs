using Scripts.UI.Events;
using UnityEngine;
using Zenject;

public class ResultController : MonoBehaviour
{
    private GameManager _gameManager;
    private CurrencyManager _currencyManager;
    private IScoreService _scoreService;

    [Inject]
    public void Construct(GameManager gameManager, CurrencyManager currencyManager, IScoreService scoreService)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
        _scoreService = scoreService;
    }

    private void OnEnable()
    {
        _scoreService.OnScoreChanged += SummarizeScore;
        _currencyManager.OnCollectedCurrency += SummarizeCurrency;
        ResultScreenEvents.OnContinueButtonPressed += ContinueGame;
    }

    private void OnDisable()
    {
        ResultScreenEvents.OnContinueButtonPressed -= ContinueGame;
    }

    private void SummarizeScore(int score)
    {
       ResultScreenEvents.OnScoreResult?.Invoke(score);

    //    var bestScoreData = _gameManager.SaveData.BestScore;
    //    TODO ADD SAVE DATA BEST RECORD
    //    ResultScreenEvents.OnBestScoreResult?.Invoke(score);
    }

    private void SummarizeCurrency(int money)
    {
       ResultScreenEvents.OnCurrencyResult?.Invoke(money);
       //    TODO ADD SAVE DATA MONEY 
    }

    private void ContinueGame()
    {
        var menuCommand = new MenuGameCommand(_gameManager);
        menuCommand.Execute();
    }
}
