using System;
using Scripts.Core.Characters;
using Scripts.UI.Events;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private const float OMITTED_CENTER_Y = 0.5f;
    private const float OMITTED_COLLIDER_HEIGHT = 2f;
    private const string OBSTACLE_TAG = "Obstacle";

    private bool _isCrashed = false;
    private PlayerStateMachine _playerStateMachine;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 1f;
    [SerializeField] private bool _cheats = false;

    private Vector3 _colliderCenter;
    private float _colliderHeight;


    public PlayerStateMachine PlayerStateMachine => _playerStateMachine;
    public Rigidbody RigidBody => _rigidbody;
    public bool IsCrashed => _isCrashed;
    public bool Cheats => _cheats;

    public event Action OnPlayerCrashed;


    private void Awake()
    {
        _playerAnimation = _playerAnimation != null ? _playerAnimation : GetComponent<PlayerAnimation>();
        _collider = _collider != null ? _collider : GetComponent<CapsuleCollider>();

        _playerStateMachine = new PlayerStateMachine(this, _playerAnimation);
        _playerStateMachine.Initialize(_playerStateMachine.IdleState);

        _colliderHeight = _collider.height;
        _colliderCenter = _collider.center;

        if (_cheats)
            EnableCheats();
    }

    private void Update()
    {
        _playerStateMachine.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_cheats)
        {
            if (other.CompareTag(OBSTACLE_TAG))
            {
                _isCrashed = true;
                OnPlayerCrashed?.Invoke();
                GameplayEvents.OnEndRunning?.Invoke();
            }
        }
    }

    private void EnableCheats()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position,
                                    Vector3.down, _groundCheckDistance, _groundLayer);
    }

    public void OmitCollider()
    {
        _collider.center = new Vector3(_collider.center.x, OMITTED_CENTER_Y, _collider.center.z);
        _collider.height = OMITTED_COLLIDER_HEIGHT;
    }

    public void ResetCollider()
    {
        _collider.center = _colliderCenter;
        _collider.height = _colliderHeight;
    }

}