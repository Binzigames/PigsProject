using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private const int STARTED_LANE = 0;

    [Header("Run")]
    private bool _canJump = false;
    [SerializeField] private float _moveOffset = 3.5f;
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 50f;
    [SerializeField] private float _gravityMultiplier = 3.5f;

    private Player _player;
    private PlayerTouchController _touchController;

    private int _currentLane;
    private Vector3 _targetPosition;

    [Inject]
    public void Construct(Player player, PlayerTouchController touchController)
    {
        _player = player;
        _touchController = touchController;
    }
    private void Awake()
    {
        Subscribe();

        _currentLane = STARTED_LANE;
    }
    private void OnDestroy()
    {
        Unsubcribe();
    }
    private void FixedUpdate()
    {
        HandleGravity();
        HandleMove();
        HandleJump();
    }
    private void Subscribe()
    {
        _touchController.OnSwipeLeft += MoveLeft;
        _touchController.OnSwipeRight += MoveRight;
        _touchController.OnSwipeDown += Slide;
        _touchController.OnSwipeUp += Jump;
    }
    private void Unsubcribe()
    {
        _touchController.OnSwipeLeft -= MoveLeft;
        _touchController.OnSwipeRight -= MoveRight;
        _touchController.OnSwipeDown -= Slide;
        _touchController.OnSwipeUp -= Jump;
    }

    private void HandleMove()
    {
        var smoothTargetPos = Vector3.Lerp(_player.RigidBody.position,
                                                _moveOffset * _targetPosition,
                                                    _moveSpeed * Time.fixedDeltaTime);
        _player.RigidBody.MovePosition(smoothTargetPos);
    }

    private void MoveLeft()
    {
        ChangeLane(-1);

    }
    private void MoveRight()
    {
        ChangeLane(1);
    }
    private void ChangeLane(int direction)
    {
        var targetLane = _currentLane + direction;

        if (targetLane < -1 || targetLane > 1)
            return;

        _currentLane = targetLane;
        _targetPosition = new Vector3(targetLane, 0, 0);
    }
    private void HandleJump()
    {
        if (_player.IsGrounded() && _canJump)
        {
            var targetJumpPos = new Vector3
                                    (_player.RigidBody.linearVelocity.x,
                                        _jumpForce, _player.RigidBody.linearVelocity.z);

            _player.RigidBody.linearVelocity = targetJumpPos;
        }
        else if (!_player.IsGrounded())
        {
            _canJump = false;
        }
    }

    private void HandleGravity()
    {
        if (_player.RigidBody.linearVelocity.y > 0)
        {
            _player.RigidBody.linearVelocity -=
                 _gravityMultiplier * Physics.gravity.y * Time.fixedDeltaTime * Vector3.down;
        }
    }

    private void Jump() => _canJump = true;

    private void Slide()
    {
        // Slide
    }








}
