namespace DevConfigs.GameStateMachine
{
    public class MenuState : GameState
    {
        
        private readonly IScoreManager _scoreManager;
        private readonly ICurrencyManager _currencyManager;
        private readonly IMusicService _musicService;
        private readonly MusicDataContainer _musicDataContainer;

        public MenuState(
            IScoreManager scoreManager, ICurrencyManager currencyManager,
                IMusicService musicService, IStaticDataProvider dataProvider)
        {
            _scoreManager = scoreManager;
            _currencyManager = currencyManager;
            _musicService = musicService;
            _musicDataContainer = dataProvider.GetDataContainer<MusicDataContainer>();
        }

        public override void Enter()
        {
            _scoreManager.ResetScore();
            _currencyManager.ResetCurrency();

            var menuMusic = _musicDataContainer.GetMusicByType(MusicType.MainMenu);
            if (menuMusic != null)
            {
                _musicService.PlayMusic(menuMusic);
            }
        }
    }
}