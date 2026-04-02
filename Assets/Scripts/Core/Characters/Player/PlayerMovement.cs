using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    private const int STARTED_LANE = 0;

    [Inject] private readonly Player _player;
    private Vector3 _targetPosition = Vector3.zero;
    private int _currentLane;
    private bool _isJumped = false;

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
        _player.transform.position = _targetPosition;
    }
    private void Subscribe()
    {
        var playerController = _player.PlayerController;

        playerController.OnSwipeLeft += MoveLeft;
        playerController.OnSwipeRight += MoveRight;
        playerController.OnSwipeDown += Slide;
        playerController.OnSwipeUp += Jump;
    }
    private void Unsubcribe()
    {
        var playerController = _player.PlayerController;

        playerController.OnSwipeLeft -= MoveLeft;
        playerController.OnSwipeRight -= MoveRight;
        playerController.OnSwipeDown -= Slide;
        playerController.OnSwipeUp -= Jump;
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
        _player.RigidBody.AddForce(_jumpForce *  Vector3.up, ForceMode.Impulse);
    }
    private void Slide()
    {
        // Slide
    }








}
