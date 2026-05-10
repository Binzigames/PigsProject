using Scripts.UI.Events;
using UnityEngine;
using Zenject;

public class ResultController : MonoBehaviour
{
    private GameManager _gameManager;
    private CurrencyManager _currencyManager;

    [Inject]
    public void Construct(GameManager gameManager, CurrencyManager currencyManager)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
    }

    private void OnEnable()
    {
        ResultScreenEvents.OnScoreResult += SummarizeScore;
        ResultScreenEvents.OnCurrencyResult += SummarizeCurrency;
        ResultScreenEvents.OnContinueButtonPressed += ContinueGame;
    }

    private void OnDisable()
    {
        ResultScreenEvents.OnScoreResult -= SummarizeScore;
        ResultScreenEvents.OnCurrencyResult -= SummarizeCurrency;
        ResultScreenEvents.OnContinueButtonPressed -= ContinueGame;
    }

    private void SummarizeScore(string score)
    {
        // get score reached
    }

    private void SummarizeCurrency(string currency)
    {
        // get curremcy gathered
    }

    private void ContinueGame()
    {
        var menuCommand = new MenuGameCommand(_gameManager);
        menuCommand.Execute();
    }
}
