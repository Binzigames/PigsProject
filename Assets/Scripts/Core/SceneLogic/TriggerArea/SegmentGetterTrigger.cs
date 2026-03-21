using UnityEngine;
using Zenject;

public class SegmentGetterTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    [Inject] private SegmentGenerator _segmentPool;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_TAG))
        {
            _segmentPool.GetSegmentFromPool();
        }
    }
}
