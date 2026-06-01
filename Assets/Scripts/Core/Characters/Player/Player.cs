using Scripts.Core.Characters;
using Scripts.UI.Events;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private const string OBSTACLE_TAG = "Obstacle";

    private bool _isCrashed = false;
    private PlayerStateMachine _playerStateMachine;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _mainCollider;
    [SerializeField] private BoxCollider _slideCollider;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 1f;


    public PlayerStateMachine PlayerStateMachine => _playerStateMachine;
    public Rigidbody RigidBody => _rigidbody;
    public bool IsCrashed => _isCrashed;
    

    private void Awake()
    {
        _playerAnimation = _playerAnimation != null ? _playerAnimation : GetComponent<PlayerAnimation>();
        _mainCollider = _mainCollider != null ? _mainCollider : GetComponent<CapsuleCollider>();
        _slideCollider = _slideCollider != null ? _slideCollider : GetComponent<BoxCollider>();
        _slideCollider.enabled = false;
        

        _playerStateMachine = new PlayerStateMachine(this, _playerAnimation);
        _playerStateMachine.Initialize(_playerStateMachine.IdleState);
    }

    private void Update()
    {
        _playerStateMachine.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OBSTACLE_TAG))
        {
            _isCrashed = true;
            GameplayEvents.OnEndRunning?.Invoke();
        }
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position,
                                    Vector3.down, _groundCheckDistance, _groundLayer);
    }

    public void SwapColliders()
    {
        _mainCollider.enabled = !_mainCollider.enabled;
        _slideCollider.enabled = !_slideCollider.enabled;
    }

    public void ResetColliders()
    {
        _mainCollider.enabled = true;
        _slideCollider.enabled = false;
    }

}