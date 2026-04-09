using Assets.Scripts.Patterns.ObjectPool;
using UnityEngine;
using Zenject;

public class SegmentManager : MonoBehaviour
{
    [Inject] private readonly ObjectPool _objectPool;

    [SerializeField] private float _segmentsMoveSpeed;
    [SerializeField] private Transform _spawnPosition;

    private void FixedUpdate()
    {
        MoveSegmentsIfActive();
    }

    private void MoveSegmentsIfActive()
    {
        foreach (var segment in _objectPool.PooledObjectList)
        {
            if (segment.activeInHierarchy)
            {
                MoveSegment(segment);
            }
        }
    }
    private void MoveSegment(GameObject segment)
    {
        segment.transform.position += _segmentsMoveSpeed * Time.fixedDeltaTime * Vector3.back;
    }

    public void GetSegmentFromPool()
    {
        var pooledSegment = _objectPool.GetObjectFromPool();
        pooledSegment.transform.SetPositionAndRotation(_spawnPosition.position, Quaternion.identity);
    }

    public void ReleaseSegmentToPool(GameObject gameObject)
    {
        _objectPool.ReleaseObjectToPool(gameObject);
    }
}