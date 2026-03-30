using Assets.Scripts.Patterns.ObjectPool;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSegments();
        BindPlayer();
    }
    
    private void BindSegments()
    {
        Container.Bind<SegmentGenerator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SegmentManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
    }
    private void BindPlayer()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}
