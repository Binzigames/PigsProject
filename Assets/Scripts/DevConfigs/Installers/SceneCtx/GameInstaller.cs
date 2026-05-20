using Assets.Scripts.Patterns.ObjectPool;
using Zenject;
using UnityEngine;
using Unity.Cinemachine;

public class GameInstaller : MonoInstaller
{
    [Header("Player")]
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Vector3 _playerInitPos;
    
    [Header("Other")]
    [SerializeField] private CinemachineCamera _cinemachineCamera;
    public override void InstallBindings()
    {
        BindSegments();
        BindPlayer();
        BindSaveProcessor();
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
        
        if (_cinemachineCamera != null)
        {
            _cinemachineCamera.Follow = player.transform;
        }
    }

    private void BindSaveProcessor()
    {
        Container.Bind<ISaveProcessor<SaveData>>().To<PlayerPrefsSaveProcessor<SaveData>>().AsSingle();
    }
}
