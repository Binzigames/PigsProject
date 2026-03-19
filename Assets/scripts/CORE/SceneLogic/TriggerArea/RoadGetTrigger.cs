using UnityEngine;
using Zenject;

public class RoadGetTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    [Inject] private SegmentPool _segmentPool;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_TAG))
        {
            _segmentPool.GetRoadFromPool();
        }
    }
}
