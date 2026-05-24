using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [Header("Managers")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private ScoreManager _scoreManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManager).AsSingle().NonLazy();
        BindManagers();
    }

    private void BindManagers()
    {
        Container.Bind<CurrencyManager>().FromComponentInNewPrefab(_currencyManager).AsSingle().NonLazy();
        Container.Bind<IScoreService>().To<ScoreManager>().FromComponentInNewPrefab(_scoreManager).AsSingle().NonLazy();
    }
}