using Scripts.Patterns.Commands;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    private AudioClip _buttonAudioClip;

    private Player _player;
    private GameManager _gameManager;
    private ISoundService _soundService;
    private SoundDataContainer _soundDataContainer;

    [Inject]
    public void Construct(
        Player player, GameManager gameManager,
            ISoundService soundService, IStaticDataProvider dataProvider)
    {
        _player = player;
        _gameManager = gameManager;
        _soundService = soundService;
        _soundDataContainer = dataProvider.GetDataContainer<SoundDataContainer>();
    }

    private void OnEnable()
    {
        MainMenuEvents.OnPlayButtonPressed += StartGame;
        MainMenuEvents.OnSettingButtonPressed += OnSettingButton;

        SetBestScore();
        SetTotalMoney();

        _buttonAudioClip = _soundDataContainer.Button;
    }

    private void OnDisable()
    {
        MainMenuEvents.OnPlayButtonPressed -= StartGame;
        MainMenuEvents.OnSettingButtonPressed -= OnSettingButton;
    }

    private void SetBestScore()
    {
        var data = _gameManager.SaveData.BestScore;
        MainMenuEvents.OnShowedBestScore?.Invoke(data);
    }

    private void SetTotalMoney()
    {
        var data = _gameManager.SaveData.Money;
        MainMenuEvents.OnShowedTotalMoney?.Invoke(data);
    }

    private void StartGame()
    {
        var startGameCommand = new StartGameCommand(_player, _gameManager);
        startGameCommand.Execute();
    }

    private void OnSettingButton()
    {
        _soundService.PlayClip(_buttonAudioClip);
    }
}