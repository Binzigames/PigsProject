using UnityEngine;
using UnityEngine.Pool;


namespace Scripts.Core.SceneLogic
{
    public class Obstacle : MonoBehaviour
    {
        public IObjectPool<Obstacle> ObstaclePool { get; set; }
    }
}