using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Scripts.Core.SceneLogic
{
    public class ObstacleGenerator : MonoBehaviour
    {
        private DiContainer _diContainer;
        private ObstacleDataContainer _obstacleDataContainer;

        [SerializeField] private int _defaultPoolCapacity = 10;
        [SerializeField] private int _maxPoolSize = 15;

        private IObjectPool<Obstacle> _obstaclePool;

        private List<Obstacle> _obstaclePrefabList;
        private List<Obstacle> _pooledObstacleList;


        private int _indexPrefabList = -1;

        public IObjectPool<Obstacle> Pool => _obstaclePool;
        public List<Obstacle> PooledObstacleList => _pooledObstacleList;


        [Inject]
        public void Construct(IStaticDataProvider dataProvider, DiContainer container)
        {
            _obstacleDataContainer = dataProvider.GetDataContainer<ObstacleDataContainer>();
            _diContainer = container;
        }

        private void Awake()
        {
            Debug.Log(_obstacleDataContainer);
            _obstaclePrefabList = _obstacleDataContainer.GetObstacleList();

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
                _indexPrefabList++;
            }
            else
            {
                _indexPrefabList = 0; //Reset index
            }

            return _obstaclePrefabList[_indexPrefabList];
        }
        private void OnGetObstacle(Obstacle obstacle)
        {
            if (!_pooledObstacleList.Contains(obstacle))
            {
                _pooledObstacleList.Add(obstacle);
            }
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
}