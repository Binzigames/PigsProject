using Scripts.Core.Characters;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    private const string OBSTACLE_TAG = "Obstacle";

    private bool _isCrashed = false;
    private PlayerAnimation _playerAnimation;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 1f;


    public PlayerStateMachine PlayerStateMachine;
    public bool IsCrashed => _isCrashed;
    public Rigidbody RigidBody => _rigidbody;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();

        PlayerStateMachine = new PlayerStateMachine(this, _playerAnimation);
        PlayerStateMachine.Initialize(PlayerStateMachine.IdleState);
    }

    private void Update()
    {
        PlayerStateMachine.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OBSTACLE_TAG))
        {
            _isCrashed = true;
        }
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position,
                                    Vector3.down, _groundCheckDistance, _groundLayer);
    }

}