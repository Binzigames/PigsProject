using UnityEngine;
using Zenject;

public class RoadReleaseTrigger : MonoBehaviour
{
    [Inject] private SegmentPool _roadPool;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Road>(out Road road))
        {
            _roadPool.ReleaseRoadToPool(road);
        }    
    }
}
