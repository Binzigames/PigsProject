using UnityEngine;
using Zenject;

public class SegmentReleaseTrigger : MonoBehaviour
{
    private const string SEGMENT_TAG = "Segment";
    [Inject] private readonly SegmentManager _segmentManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(SEGMENT_TAG))
        {
            _segmentManager.ReleaseSegmentToPool(other.gameObject);
        }
    }
}