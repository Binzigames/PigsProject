using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    private AudioClip _buttonAudioClip;

    private GameManager _gameManager;
    private ILoadSceneService _sceneLoadService;
    private ISoundService _soundService;
    private SoundDataContainer _soundDataContainer;

    [Inject]
    public void Construct(GameManager gameManager, ILoadSceneService sceneLoadService,
        ISoundService soundService, IStaticDataProvider dataProvider)
    {
        _gameManager = gameManager;
        _sceneLoadService = sceneLoadService;
        _soundService = soundService;
        _soundDataContainer = dataProvider.GetDataContainer<SoundDataContainer>();
    }

    private void OnEnable()
    {
        PauseEvents.OnResumeButtonPressed += ResumeGame;
        PauseEvents.OnEndRunButtonPressed += EndRun;

        _buttonAudioClip = _buttonAudioClip != null ? _buttonAudioClip : _soundDataContainer.Button;
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
        var loadMenuCommand = new LoadMenuCommand(_gameManager, _sceneLoadService);
        loadMenuCommand.Execute();

        _soundService.PlayClip(_buttonAudioClip);
    }

}
