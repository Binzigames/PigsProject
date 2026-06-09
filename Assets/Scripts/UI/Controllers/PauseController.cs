using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    private GameManager _gameManager;
    private ILoadSceneService _sceneLoadService;

    [Inject]
    public void Construct(GameManager gameManager, ILoadSceneService sceneLoadService)
    {
        _gameManager = gameManager;
        _sceneLoadService = sceneLoadService;
    }

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
        var endGameCommand = new MenuGameCommand(_gameManager, _sceneLoadService);
        endGameCommand.Execute();
    }

}
