using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SegmentDataContainer), menuName = "SciptableObject/DataContainer/" + nameof(SegmentDataContainer))]
public class SegmentDataContainer : BaseStaticDataContainer
{
    [SerializeField] private List<Segment> _segmentPrefabList;

    public List<Segment> GetSegmentPrefabList()
    {
        return _segmentPrefabList;
    }
}
