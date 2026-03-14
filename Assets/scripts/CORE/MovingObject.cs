using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float destroyZ = -30f;

    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
