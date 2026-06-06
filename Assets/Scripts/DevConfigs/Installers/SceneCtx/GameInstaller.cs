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

    [Header("Service")]
    [SerializeField] private SoundService _soundService;
    [SerializeField] private MusicService _musicService;

    [Header("Other")]
    [SerializeField]
    private CinemachineCamera _cinemachineCamera;

    public override void InstallBindings()
    {
        BindSegments();
        BindPlayer();
        BindAudioServices();
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

    private void BindAudioServices()
    {
        Container.Bind<ISoundService>().To<SoundService>().FromComponentInNewPrefab(_soundService).AsSingle().NonLazy();
        Container.Bind<IMusicService>().To<MusicService>().FromComponentInNewPrefab(_musicService).AsSingle().NonLazy();
    }

}
