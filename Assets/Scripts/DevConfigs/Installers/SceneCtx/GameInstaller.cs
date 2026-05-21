using Assets.Scripts.Patterns.ObjectPool;
using Zenject;
using UnityEngine;
using Unity.Cinemachine;

public class GameInstaller : MonoInstaller
{
    [Header("Player")]
    [SerializeField]
    private Player _playerPrefab;

    [SerializeField]
    private Vector3 _playerInitPos;

    [Header("Other")]
    [SerializeField]
    private CinemachineCamera _cinemachineCamera;

    [SerializeField]
    private GameObject _currencyManager;

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
                                        .OnInstantiated<Player>(InitPlayer).NonLazy();
        Container.Bind<PlayerTouchController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerInteraction>().FromComponentInHierarchy().AsSingle();
    }

    private void InitPlayer(InjectContext ctx, Player player)
    {
        player.transform.position = _playerInitPos;

        if (_cinemachineCamera != null)
        {
            _cinemachineCamera.Follow = player.transform;
        }
    }

    private void BindManagers()
    {
        Container.Bind<CurrencyManager>().FromComponentInNewPrefab(_currencyManager).AsSingle().NonLazy();
    }

}
