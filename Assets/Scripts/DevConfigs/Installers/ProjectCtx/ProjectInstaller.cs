using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManager).AsSingle().NonLazy();
    }
}