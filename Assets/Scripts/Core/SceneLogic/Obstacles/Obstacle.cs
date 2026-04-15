using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Scripts.Core.SceneLogic
{
    public class Obstacle : MonoBehaviour
    {
        [Inject] private readonly Player _player;
        public IObjectPool<Obstacle> ObstaclePool { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_player.tag))
            {
                Debug.Log($"Collision with the {other}");
            }
        }
    }
}