using UnityEngine;
using Zenject;

public class HUDController : MonoBehaviour
{
    private AudioClip _buttonAudioClip;

    private GameManager _gameManager;
    private ICurrencyManager _currencyManager;
    private IScoreManager _scoreManager;
    private ISoundService _soundService;
    private SoundDataContainer _soundDataContainer;

    [Inject]
    public void Costruct(
        GameManager gameManager, ICurrencyManager currencyManager,
            IScoreManager scoreManager, ISoundService soundService, IStaticDataProvider dataProvider)
    {
        _gameManager = gameManager;
        _currencyManager = currencyManager;
        _scoreManager = scoreManager;
        _soundService = soundService;
        _soundDataContainer = dataProvider.GetDataContainer<SoundDataContainer>();
    }

    private void OnEnable()
    {
        HUDEvents.OnPausePressed += PauseGame;

        _currencyManager.OnCollectedCurrency += HandleCurrencyLabel;
        _scoreManager.OnScoreChanged += HandleScoreLabel;

        _buttonAudioClip = _buttonAudioClip != null ? _buttonAudioClip : _soundDataContainer.Button;
    }

    private void OnDisable()
    {
        HUDEvents.OnPausePressed -= PauseGame;

        _currencyManager.OnCollectedCurrency -= HandleCurrencyLabel;
        _scoreManager.OnScoreChanged -= HandleScoreLabel;
    }

    private void HandleCurrencyLabel(int value)
    {
        HUDEvents.OnChangedCurrency?.Invoke(value);
    }

    private void HandleScoreLabel(int score)
    {
        HUDEvents.OnChangedScore?.Invoke(score);
    }

    private void PauseGame()
    {
        var pauseCommand = new PauseGameCommand(_gameManager);
        pauseCommand.Execute();

        _soundService.PlayClip(_buttonAudioClip);
    }
}
