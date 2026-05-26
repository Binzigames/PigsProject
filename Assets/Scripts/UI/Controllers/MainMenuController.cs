using Scripts.Patterns.Commands;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    private Player _player;
    private GameManager _gameManager;

    [Inject]
    public void Construct(Player player, GameManager gameManager)
    {
        _player = player;
        _gameManager = gameManager;
    }

    private void OnEnable()
    {
        MainMenuEvents.OnPlayButtonPressed += StartGame;
        MainMenuEvents.OnShowedBestScore += SetBestScore;
        MainMenuEvents.OnShowedTotalMoney += SetTotalMoney;
    }
    private void OnDisable()
    {
        MainMenuEvents.OnPlayButtonPressed -= StartGame;
        MainMenuEvents.OnShowedBestScore -= SetBestScore;
        MainMenuEvents.OnShowedTotalMoney = SetTotalMoney;
    }

    private void StartGame()
    {
        var startGameCommand = new StartGameCommand(_player, _gameManager);
        startGameCommand.Execute();
    }

    private void SetBestScore(int bestScore)
    {
        _ = _gameManager.SaveData.BestScore;
    }

    private void SetTotalMoney(int money)
    {
        _ = _gameManager.SaveData.Money;
    }
}