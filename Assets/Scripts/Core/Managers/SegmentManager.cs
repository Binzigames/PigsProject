using UnityEngine;
using Zenject;

public class SegmentManager : MonoBehaviour
{
    private Player _player;
    private SegmentGenerator _segmentGenerator;
    [SerializeField] private float _segmentsMoveSpeed;
    [SerializeField] private float _despawnZDistance;

    [Inject]
    public void Construct(Player player, SegmentGenerator segmentGenerator)
    {
        _player = player;
        _segmentGenerator = segmentGenerator;
    }

    private void Update()
    {
        ReleaseSegmentOnDistance();
    }

    private void FixedUpdate()
    {
        MoveSegmentsIfActive();
    }

    private void MoveSegmentsIfActive()
    {
        foreach (Segment segment in _segmentGenerator.PoolList)
        {
            if (segment.isActiveAndEnabled)
            {
                MoveSegment(segment);
            }
        }
    }
    private void MoveSegment(Segment segment)
    {
        segment.gameObject.transform.position += _segmentsMoveSpeed * Time.fixedDeltaTime * Vector3.back;
    }
    private void ReleaseSegmentOnDistance()
    {
        foreach (Segment segment in _segmentGenerator.PoolList)
        {
            var distanceToRelease = _player.transform.position.z - segment.transform.position.z;
            Debug.Log(distanceToRelease);
            if (segment.gameObject.activeInHierarchy && distanceToRelease >= _despawnZDistance)
            {
                _segmentGenerator.ReleaseSegmentToPool(segment);
            }
        }
    }
}