using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class SegmentGenerator : MonoBehaviour
{
    [Inject] private readonly DiContainer _container;
    private IObjectPool<Segment> _segmentPool;
    [SerializeField] private List<Segment> _segmentPrefabList;
    [SerializeField] private List<Segment> _poolList;
    [SerializeField] private Transform _spawnPosition;
    private int _indexPrefabList = 0;

    [SerializeField] private int _defaultPoolCapacity = 5;
    [SerializeField] private int _maxPoolSize = 10;

    public List<Segment> SegmentPrefabList => _segmentPrefabList;
    public List<Segment> PoolList => _poolList;

    private void Awake()
    {
        
        _segmentPool = new ObjectPool<Segment>
        (CreateInstance, OnGetFromPool, OnReleaseToPool, OnDestroyPooled,
            collectionCheck: true, _defaultPoolCapacity, _maxPoolSize);
    
        AddPrefabsToPool();
        GetSegmentFromPool();
    }

    private Segment CreateInstance()
    {
        var segmentPrefab = GetNextSegmentPrefab();
        
        Segment segmentInstance = _container.InstantiatePrefabForComponent<Segment>(segmentPrefab, gameObject.transform);
        segmentInstance.SegmentPool = _segmentPool;
        _indexPrefabList ++;
        return segmentInstance;
    }
    private Segment GetNextSegmentPrefab()
    {
        if (_indexPrefabList <= _segmentPrefabList.Count)
        {
            _indexPrefabList ++;
        }
        else
        {
            _indexPrefabList = 0; //Reset index
        }

        return _segmentPrefabList[_indexPrefabList];
    }
    private void OnGetFromPool(Segment segment)
    {
        EnsureExistInList(segment);
        segment.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(Segment segment)
    {
        segment.gameObject.SetActive(false);
    }
    private void OnDestroyPooled(Segment segment) // If you hit maximum limit
    {
        Destroy(segment.gameObject);
    }
    private void AddPrefabsToPool()
    {
        foreach (Segment segment in _segmentPrefabList)
        {
            segment.SegmentPool = _segmentPool;
        }
    }
    private void EnsureExistInList(Segment segment)
    {
        if (!_poolList.Contains(segment))
        {
            _poolList.Add(segment);
        }
        return;
    }

    public void GetSegmentFromPool()
    {
        var segmentFromPool = _segmentPool.Get();
        segmentFromPool.transform.SetPositionAndRotation(_spawnPosition.position, Quaternion.identity);
    }
    public void ReleaseSegmentToPool(Segment segment)
    {
        _segmentPool.Release(segment);
    }
}