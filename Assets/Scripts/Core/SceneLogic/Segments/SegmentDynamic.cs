using System.Collections.Generic;
using System.Linq;
using Scripts.Core.SceneLogic;
using UnityEngine;

public class SegmentDynamic : Segment
{
    private const string PLAYER_TAG = "Player";

    [SerializeField] 
    private List<DynamicObstacle> _dynamicObstaclesList;

    private bool _isTriggered = false;

    private void OnValidate()
    {
        _dynamicObstaclesList = gameObject.GetComponentsInChildren<DynamicObstacle>().ToList();
    }

    private void OnDisable()
    {
        _isTriggered = false;
    }

    private void FixedUpdate()
    {
        if (_isTriggered)
        {
            for (int i = 0; i < _dynamicObstaclesList.Count; i++)
            {
                MoveObstacle(_dynamicObstaclesList[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            _isTriggered = true;
        }
    }

    private void MoveObstacle(IMovableObstacle movableObstacle)
    {
        movableObstacle.MoveObstacle();
    }

}
