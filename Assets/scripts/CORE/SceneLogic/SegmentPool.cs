using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class SegmentPool : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    private IObjectPool<Road> _roadPool;
    [SerializeField] private List<Road> _roadInPoolList;

    [SerializeField] private Road[] _roadPrefabList;
    [SerializeField] private Road _startedRoadPrefab;
    [SerializeField] private Vector3 _spawnPosition;
    

    [SerializeField] private int _defaultPoolCapacity = 5;
    [SerializeField] private int _maxPoolSize = 10;

    private void Awake()
    {
        _roadPool = new ObjectPool<Road>
        (CreateRoadInstance, OnGetFromPool, OnReleaseToPool, OnDestroyPooledRoad,
            collectionCheck: true, _defaultPoolCapacity, _maxPoolSize);

        AddExistRoadToPool();
    }
    private void AddExistRoadToPool()
    {
        _startedRoadPrefab.RoadPool = _roadPool;
        EnsureExistInList(_startedRoadPrefab);
    }
    private void EnsureExistInList(Road road)
    {
        if (!_roadInPoolList.Contains(road))
        {
            _roadInPoolList.Add(road);
        }
        return;
    }

    private Road CreateRoadInstance()
    {
        var _randomRoadPrefab = _roadPrefabList[Random.Range(0, _roadPrefabList.Length)];
        Road roadInstance = _container.InstantiatePrefabForComponent<Road>(_randomRoadPrefab);
        roadInstance.RoadPool = _roadPool;
        return roadInstance;
    }
    private void OnGetFromPool(Road pooledRoad)
    {
        EnsureExistInList(pooledRoad);
        pooledRoad.gameObject.SetActive(true);
    }
    
    private void OnReleaseToPool(Road pooledRoad)
    {
        pooledRoad.gameObject.SetActive(false);
    }
    private void OnDestroyPooledRoad(Road pooledRoad) // If you hit maximum limit
    {
        Destroy(pooledRoad.gameObject);
    }

    public void GetRoadFromPool()
    {
        var roadFromPool = _roadPool.Get();
        roadFromPool.transform.SetPositionAndRotation(_spawnPosition, Quaternion.identity);
    }
    public void ReleaseRoadToPool(Road road)
    {
        _roadPool.Release(road);
    }
}