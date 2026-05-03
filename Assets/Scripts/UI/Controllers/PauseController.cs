using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    [Inject] private GameManager _gameManager;

    private void OnEnable()
    {
        PauseEvents.OnResumeButtonPressed += ResumeGame;
        PauseEvents.OnEndRunButtonPressed += EndRun;
    }

    private void OnDisable()
    {
        PauseEvents.OnResumeButtonPressed -= ResumeGame;
        PauseEvents.OnEndRunButtonPressed -= EndRun;   
    }

    private void ResumeGame()
    {
        var resumeGameCommand = new ResumeGameCommand(_gameManager);
        resumeGameCommand.Execute();
    }

    private void EndRun()
    {
        var endGameCommand = new EndGameCommand(_gameManager);
        endGameCommand.Execute();
    }

}
