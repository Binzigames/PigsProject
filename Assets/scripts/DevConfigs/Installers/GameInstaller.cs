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
    }
    private void BindPlayer()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}
