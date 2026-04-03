using TMPro;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private const int STARTED_LANE = 0;

    [SerializeField] private float _moveOffset = 3f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

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
        HandleMove();
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
        var targetLanePosition = Vector3.Lerp(transform.position,
                                                _moveOffset * _targetPosition,
                                                    _moveSpeed * Time.deltaTime);
        transform.position = targetLanePosition;
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
    private void Jump()
    {
        if (_player.IsGrounded())
        {
            _player.RigidBody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
    private void Slide()
    {
        // Slide
    }








}
