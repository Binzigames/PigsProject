using DevConfigs.GameStateMachine;
using Scripts.UI.Events;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private CurrencyManager _currencyManager;
    private IScoreService _scoreService;
    private IUnityLifecycleEventListener _lifecycleListener;
    private ISaveProcessor<SaveData> _saveProcessor;
    private SaveData _saveData;

    private GameStateMachine _gameStateMachine;
    private GameStateFactory _gameStateFactory;

    public SaveData SaveData => _saveData;
    public GameStateMachine GameStateMachine => _gameStateMachine;
    public GameStateFactory GameStateFactory => _gameStateFactory;

    [Inject]
    public void Contruct(IScoreService scoreService, ISaveProcessor<SaveData> saveProcessor, IUnityLifecycleEventListener lifecycleListener, CurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
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
        _gameStateFactory = new GameStateFactory(this, _scoreService, _currencyManager);

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
        Debug.Log("Focused Saved");
    }

    private void OnApplicationPauseHandler(bool pause)
    {
        Save();
        Debug.Log("Paused Saved");
    }

    private void OnApplicationQuitHandler()
    {
        Save();
        Debug.Log("Exit Saved");
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
