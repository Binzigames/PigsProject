using UnityEngine;
using UnityEngine.Pool;

public class Road : MonoBehaviour
{
    public IObjectPool<Road> RoadPool {get; set;}

    [SerializeField] private float _moveSpeed = 1f;

    private void FixedUpdate()
    {
        MoveRoad();
    }
    private void MoveRoad()
    {
        transform.position += _moveSpeed * Time.fixedDeltaTime * Vector3.back;
    }
}