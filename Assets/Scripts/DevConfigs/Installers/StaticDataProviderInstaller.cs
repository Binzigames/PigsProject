using System.Collections.Generic;
using Zenject;
using UnityEngine;

public class StaticDataProviderInstaller : MonoInstaller
{
    [SerializeField] private List<BaseStaticDataContainer> _dataContainerList;
    public override void InstallBindings()
    {
        Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle().WithArguments(_dataContainerList);
    }
}