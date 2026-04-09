using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 1f;

    public Rigidbody RigidBody => _rigidbody;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position,
                                    Vector3.down, _groundCheckDistance, _groundLayer);
    }

}