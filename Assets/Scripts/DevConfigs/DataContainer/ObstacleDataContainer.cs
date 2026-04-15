using System.Collections.Generic;
using UnityEngine;
using Scripts.Core.SceneLogic;

[CreateAssetMenu(fileName = "ObstacleDataContainer", menuName = "ScriptableObject/DataContainer/" + nameof(ObstacleDataContainer))]
public class ObstacleDataContainer : BaseStaticDataContainer
{
    [SerializeField] private List<Obstacle> _obstaclePrefabList;

    public List<Obstacle> GetObstacleList()
    {
        if (_obstaclePrefabList != null)
        {
            return _obstaclePrefabList;
        }
        else
        {
            Debug.LogError($"Prefab list in {this} has no references.");
            return null;
        }
    }
}