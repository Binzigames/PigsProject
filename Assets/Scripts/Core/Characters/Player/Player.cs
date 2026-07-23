using System;
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
    [SerializeField] private bool _cheats = false;


    public PlayerStateMachine PlayerStateMachine => _playerStateMachine;
    public Rigidbody RigidBody => _rigidbody;
    public bool IsCrashed => _isCrashed;
    public bool Cheats => _cheats;

    public event Action OnPlayerCrashed;


    private void Awake()
    {
        _playerAnimation = _playerAnimation != null ? _playerAnimation : GetComponent<PlayerAnimation>();
        _mainCollider = _mainCollider != null ? _mainCollider : GetComponent<CapsuleCollider>();
        _slideCollider = _slideCollider != null ? _slideCollider : GetComponent<BoxCollider>();
        _slideCollider.enabled = false;


        _playerStateMachine = new PlayerStateMachine(this, _playerAnimation);
        _playerStateMachine.Initialize(_playerStateMachine.IdleState);

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
        _mainCollider.isTrigger = true;
        _slideCollider.isTrigger = true;
        _rigidbody.isKinematic = true;
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