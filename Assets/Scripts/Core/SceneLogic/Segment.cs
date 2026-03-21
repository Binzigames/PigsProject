using System;
using UnityEngine;
using UnityEngine.Pool;

public class Segment : MonoBehaviour
{
    public IObjectPool<Segment> SegmentPool {get; set;}

}