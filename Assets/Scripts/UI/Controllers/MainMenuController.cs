using Scripts.Patterns.Commands;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    [Inject] private GameManager _gameManager;
    
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
        var startGameCommand = new StartGameCommand(_gameManager);
        startGameCommand.Execute();
    }
}