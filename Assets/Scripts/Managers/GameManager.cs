using DevConfigs.GameStateMachine;
using Scripts.UI.Events;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IScoreService _scoreService;

    private GameStateMachine _gameStateMachine;
    private GameStateFactory _gameStateFactory;

    private ISaveProcessor<SaveData> _saveProcessor;
    private SaveData _saveData;

    private IUnityLifecycleEventListener _lifecycleListener;

    public GameStateMachine GameStateMachine => _gameStateMachine;
    public GameStateFactory GameStateFactory => _gameStateFactory;

    [Inject]
    public void Contruct(IScoreService scoreService, ISaveProcessor<SaveData> saveProcessor, IUnityLifecycleEventListener lifecycleListener)
    {
        _scoreService = scoreService;
        _saveProcessor = saveProcessor;
        _lifecycleListener = lifecycleListener;
    }

    private void Awake()
    {
        Init();
        SubToEvents();
    }

    private void OnDestroy()
    {
        UnsubFromEvents();
    }

    private void Init()
    {
        Load();

        _gameStateMachine = new GameStateMachine();
        _gameStateFactory = new GameStateFactory(_scoreService);

        var menuState = _gameStateFactory.GetGameState(GameStateType.MenuState);
        _gameStateMachine.Initialize(menuState);
    }

    private void SubToEvents()
    {
        GameplayEvents.OnEndRunning += TransitionToResultState;

        _lifecycleListener.OnApplicationFocusCallback += OnApplicationFocusHandler;
        _lifecycleListener.OnApplicationPauseCallback += OnApplicationPauseHandler;
        _lifecycleListener.OnApplicationQuitCallback += OnApplicationQuitHandler;
    }

    private void UnsubFromEvents()
    {
        GameplayEvents.OnEndRunning -= TransitionToResultState;

        _lifecycleListener.OnApplicationFocusCallback -= OnApplicationFocusHandler;
        _lifecycleListener.OnApplicationPauseCallback -= OnApplicationPauseHandler;
        _lifecycleListener.OnApplicationQuitCallback -= OnApplicationQuitHandler;

    }

    private void TransitionToResultState()
    {
        var endState = _gameStateFactory.GetGameState(GameStateType.EndRunningState);
        _gameStateMachine.TransitionTo(endState);
    }

    private void OnApplicationFocusHandler(bool focus)
    {
        Save();
    }

    private void OnApplicationPauseHandler(bool pause)
    {
        Save();
    }

    private void OnApplicationQuitHandler()
    {
        Save();
    }

    private void Load()
    {
        _saveData = _saveProcessor.Load();
    }

    private void Save()
    {
        _saveProcessor.Save(_saveData);
    }
}
