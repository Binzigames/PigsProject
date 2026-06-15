using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _cameraYPos;

    private void Awake()
    {
        _cameraYPos = transform.position.y;
    }
    
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, _cameraYPos, transform.position.z);
    }
}
