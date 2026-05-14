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
    }
    private void OnDisable()
    {
        MainMenuEvents.OnPlayButtonPressed -= StartGame;
    }

    private void StartGame()
    {
        var startGameCommand = new StartGameCommand(_player, _gameManager);
        startGameCommand.Execute();
    }
}