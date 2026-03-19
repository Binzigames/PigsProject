using System.Threading;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindObjectPool();
    }
    

    private void BindObjectPool()
    {
        Container.Bind<SegmentPool>().FromComponentInHierarchy().AsSingle();
    }
}
