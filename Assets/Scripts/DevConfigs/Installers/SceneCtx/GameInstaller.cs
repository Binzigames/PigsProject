using Assets.Scripts.Patterns.ObjectPool;
using Zenject;
using UnityEngine;
using Unity.Cinemachine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private CinemachineCamera _cinemachineCamera;
    [SerializeField] private Vector3 _playerInitPos;
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
        Container.Bind<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle()
                                        .OnInstantiated<Player>(SetPlayer).NonLazy();
        Container.Bind<PlayerTouchController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerInteraction>().FromComponentInHierarchy().AsSingle();
    }

    private void SetPlayer(InjectContext ctx, Player player)
    {
        player.transform.position = _playerInitPos;
        _cinemachineCamera.Follow = player.transform;
    }

    private void BindManagers()
    {
        Container.Bind<CurrencyManager>().FromComponentInNewPrefab(_currencyManager).AsSingle().NonLazy();
    }
}
