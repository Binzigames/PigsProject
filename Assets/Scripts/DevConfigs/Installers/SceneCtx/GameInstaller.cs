using Assets.Scripts.Patterns.ObjectPool;
using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _currencyManager;
    public override void InstallBindings()
    {
        BindSegments();
        BindPlayer();
        BindManagers();
    }

    private void BindSegments()
    {
        Container.Bind<SegmentManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
    }
    private void BindPlayer()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerTouchController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerInteraction>().FromComponentInHierarchy().AsSingle();
    }
    private void BindManagers()
    {
        Container.Bind<CurrencyManager>().FromComponentInNewPrefab(_currencyManager).AsSingle().NonLazy();
    }
}
