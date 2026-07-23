using DevConfigs.GameStateMachine;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private const int LEVEL_SPEED_UP_INTERVAL = 30; //every 30 seconds

    private ICurrencyManager _currencyManager;
    private IScoreManager _scoreManager;
    private IUnityLifecycleEventListener _lifecycleListener;
    private ISaveProcessor<SaveData> _saveProcessor;
    private IStaticDataProvider _dataProvider;
    private IMusicService _musicService;
    private SaveData _saveData;
    private GameSpeedTimer _gameSpeedTimer;

    private GameStateMachine _gameStateMachine;
    private GameStateFactory _gameStateFactory;

    public SaveData SaveData => _saveData;
    public GameStateMachine GameStateMachine => _gameStateMachine;
    public GameStateFactory GameStateFactory => _gameStateFactory;
    public GameSpeedTimer GameSpeedTimer => _gameSpeedTimer;

    [Inject]
    public void Construct(
        IScoreManager scoreManager, ISaveProcessor<SaveData> saveProcessor, 
            IUnityLifecycleEventListener lifecycleListener, ICurrencyManager currencyManager,
                IStaticDataProvider dataProvider, IMusicService musicService)
    {
        _currencyManager = currencyManager;
        _scoreManager = scoreManager;
        _saveProcessor = saveProcessor;
        _lifecycleListener = lifecycleListener;
        _dataProvider = dataProvider;
        _musicService = musicService;
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

    private void Update()
    {
        _gameStateMachine.Execute();
    }

    private void Init()
    {
        Load();

        _gameSpeedTimer = new GameSpeedTimer(LEVEL_SPEED_UP_INTERVAL);
        _gameStateMachine = new GameStateMachine();
        _gameStateFactory = 
            new GameStateFactory(this, _scoreManager, _currencyManager, _gameSpeedTimer, _musicService, _dataProvider);

        var menuState = _gameStateFactory.ResolveGameState<MenuState>();
        _gameStateMachine.Initialize(menuState);
    }

    private void SubToEvents()
    {
        _lifecycleListener.OnApplicationFocusCallback += OnApplicationFocusHandler;
        _lifecycleListener.OnApplicationPauseCallback += OnApplicationPauseHandler;
        _lifecycleListener.OnApplicationQuitCallback += OnApplicationQuitHandler;
    }

    private void UnsubFromEvents()
    {
        _lifecycleListener.OnApplicationFocusCallback -= OnApplicationFocusHandler;
        _lifecycleListener.OnApplicationPauseCallback -= OnApplicationPauseHandler;
        _lifecycleListener.OnApplicationQuitCallback -= OnApplicationQuitHandler;
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
