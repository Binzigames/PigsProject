using Assets.Scripts.Patterns.ObjectPool;
using UnityEngine;
using Zenject;

public class SegmentGetterTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    [Inject] private SegmentManager _segmentManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_TAG))
        {
            _segmentManager.GetSegmentFromPool();
        }
    }
}
