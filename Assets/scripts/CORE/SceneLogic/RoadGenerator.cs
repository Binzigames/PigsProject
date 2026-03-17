using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class RoadGenerator : MonoBehaviour
{
    private IObjectPool<Road> _roadPool;
    [SerializeField] private List<Road> _roadInPoolList;
    [SerializeField] private Road _roadPrefab;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private int _defaultPoolCapacity = 5;
    [SerializeField] private int _maxPoolSize = 10;

    private Road _roadFromPool;
    private Road _nextRoadToRelease;

    private void Awake()
    {
        _roadPool = new ObjectPool<Road>
        (CreateRoadInstance, OnGetFromPool, OnReleaseToPool, OnDestroyPooledRoad,
            collectionCheck: true, _defaultPoolCapacity, _maxPoolSize);

        _nextRoadToRelease = _roadInPoolList.FirstOrDefault<Road>();
        _nextRoadToRelease.RoadPool = _roadPool;
    }
    private Road CreateRoadInstance()
    {
        Road roadInstance = Instantiate(_roadPrefab, gameObject.transform);
        roadInstance.RoadPool = _roadPool;
        return roadInstance;
    }
    private void OnGetFromPool(Road pooledRoad)
    {
        _roadInPoolList.Add(pooledRoad);
        _roadFromPool = pooledRoad;
        pooledRoad.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(Road pooledRoad)
    {
        _nextRoadToRelease = _roadFromPool;
        pooledRoad.gameObject.SetActive(false);
    }
    private void OnDestroyPooledRoad(Road pooledRoad) // If you hit maximum limit
    {
        Destroy(pooledRoad.gameObject);
    }
    public void SpawnRoadFromPool()
    {
        var roadFromPool = _roadPool.Get();
        roadFromPool.transform.SetPositionAndRotation(_roadFromPool.transform.forward + _spawnPosition, Quaternion.identity);
    }
    public void ReleaseLastRoad()
    {
        _roadPool.Release(_nextRoadToRelease);
    }
}