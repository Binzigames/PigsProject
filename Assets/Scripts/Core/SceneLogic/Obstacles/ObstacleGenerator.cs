using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class ObstacleGenerator : MonoBehaviour
{
    [Inject] private readonly DiContainer _diContainer;

    private IObjectPool<Obstacle> _obstaclePool;
    [SerializeField] private List<Obstacle> _obstaclePrefabList;
    private int _indexPrefabList = -1;

    [SerializeField] private int _defaultPoolCapacity = 10;
    [SerializeField] private int _maxPoolSize = 15;

    private void Awake()
    {
        _obstaclePool = new ObjectPool<Obstacle>(CreateObstacle, OnGetObstacle, OnReleaseObstacle,
                                    OnDestroyObstacle, collectionCheck: true, _defaultPoolCapacity, _maxPoolSize);
    }

    private Obstacle CreateObstacle()
    {
        var obstaclePrefab = GetNextObstaclePrefab();
        
        Obstacle obstacleInstance = _diContainer.InstantiatePrefabForComponent<Obstacle>(obstaclePrefab, transform);
        obstacleInstance.ObstaclePool = _obstaclePool;
        return obstacleInstance;
    }
    private Obstacle GetNextObstaclePrefab()
    {
        if (_indexPrefabList <= _obstaclePrefabList.Count)
        {
            _indexPrefabList ++;
        }
        else
        {
            _indexPrefabList = 0; //Reset index
        }

        return _obstaclePrefabList[_indexPrefabList];
    }
    private void OnGetObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
    }
    private void OnReleaseObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }
    private void OnDestroyObstacle(Obstacle obstacle)
    {
        Destroy(obstacle);
    }
}