using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [Header("Managers")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private ScoreManager _scoreManager;

    [Header("Other")]
    [SerializeField] private UnityLifecycleEventListener _lifecycleListener;
    [SerializeField] private GameObject _loadingScreen;
    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManager).AsSingle().NonLazy();

        BindSaveProcessor();
        BindLifecycleEventListener();
        BindManagers();
        BindLoaders();
    }

    private void BindManagers()
    {
        Container.Bind<ICurrencyManager>().To<CurrencyManager>().FromComponentInNewPrefab(_currencyManager).AsSingle().NonLazy();
        Container.Bind<IScoreManager>().To<ScoreManager>().FromComponentInNewPrefab(_scoreManager).AsSingle().NonLazy();
    }

    private void BindSaveProcessor()
    {
        Container.Bind<ISaveProcessor<SaveData>>().To<PlayerPrefsSaveProcessor<SaveData>>().AsSingle();
    }

    private void BindLifecycleEventListener()
    {
        Container.Bind<IUnityLifecycleEventListener>()
                        .To<UnityLifecycleEventListener>()
                            .FromComponentInNewPrefab(_lifecycleListener)
                                .AsSingle()
                                    .NonLazy();
        
    }

    private void BindLoaders()
    {
        Container.Bind<LoadingView>().FromComponentInNewPrefab(_loadingScreen).AsSingle().NonLazy();
        Container.Bind<ILoadSceneService>().To<LoadSceneService>().AsSingle();
    }
}