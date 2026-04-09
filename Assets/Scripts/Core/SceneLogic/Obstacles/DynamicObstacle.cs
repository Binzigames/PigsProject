using UnityEngine;

public class DynamicObstacle : Obstacle
{
    [SerializeField] [Range(0f, 10f)] 
    private float _moveSpeed = 5f;

    private void FixedUpdate()
    {
        MoveObstacle();
    }
    private void MoveObstacle()
    {
        transform.position += Time.fixedDeltaTime * _moveSpeed * Vector3.back;
    }
}