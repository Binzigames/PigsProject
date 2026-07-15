using UnityEngine;

namespace Scripts.Core.SceneLogic
{
    public class DynamicObstacle : Obstacle, IMovableObstacle
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private Transform _respawnPoint;

        private void OnEnable()
        {
            transform.position = _respawnPoint.position;
        }

        public void MoveObstacle()
        {
            transform.position += Time.fixedDeltaTime * _moveSpeed * Vector3.back;
        }
    }
}