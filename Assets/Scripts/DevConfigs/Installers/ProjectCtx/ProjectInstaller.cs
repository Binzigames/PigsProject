using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [Header("Managers")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private UnityLifecycleEventListener _lifecycleListener;
    public override void InstallBindings()
    {
        BindSaveProcessor();
        BindLifecycleEventListener();

        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManager).AsSingle().NonLazy();
        BindManagers();

        Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
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
}