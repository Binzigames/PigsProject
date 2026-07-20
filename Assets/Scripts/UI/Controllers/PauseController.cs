using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    private AudioClip _buttonAudioClip;

    private GameManager _gameManager;
    private ILoadSceneService _sceneLoadService;
    private ISoundService _soundService;
    private IMusicService _musicService;
    private AudioDataContainer _audioDataContainer;

    [Inject]
    public void Construct(GameManager gameManager, ILoadSceneService sceneLoadService,
        ISoundService soundService, IStaticDataProvider dataProvider)
    {
        _gameManager = gameManager;
        _sceneLoadService = sceneLoadService;
        _soundService = soundService;
        _audioDataContainer = dataProvider.GetDataContainer<AudioDataContainer>();
    }

    private void OnEnable()
    {
        PauseEvents.OnResumeButtonPressed += ResumeGame;
        PauseEvents.OnEndRunButtonPressed += EndRun;

        _buttonAudioClip = _buttonAudioClip != null ? _buttonAudioClip : _audioDataContainer.Button;
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

        _soundService.PlayClip(_buttonAudioClip);
    }

    private void EndRun()
    {
        var endGameCommand = new MenuGameCommand(_gameManager, _sceneLoadService);
        endGameCommand.Execute();

        _soundService.PlayClip(_buttonAudioClip);
    }

}
