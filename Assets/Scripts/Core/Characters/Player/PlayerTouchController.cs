using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class PlayerTouchController : MonoBehaviour
{
    private const string TOUCH_ACTION_NAME = "TouchScreenPress";
    [SerializeField] private float _minSwipeDistance = 50f;

    [SerializeField] private PlayerInput _playerInput;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    private  InputAction _touchAction;

    public event Action OnSwipeRight;
    public event Action OnSwipeLeft;
    public event Action OnSwipeUp;
    public event Action OnSwipeDown;

    private void Awake()
    {
        _playerInput = _playerInput != null ? _playerInput : GetComponent<PlayerInput>();

        _touchAction = _playerInput.actions[TOUCH_ACTION_NAME];
        
        _touchAction.started += OnTouchPress;
        _touchAction.canceled += OnTouchPress;
    }

    private void OnDestroy()
    {
        _touchAction.started -= OnTouchPress;
        _touchAction.canceled -= OnTouchPress;
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        if (context.canceled)
        {
            _endTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            DetectSwipeDirection();
        }
    }
    private void DetectSwipeDirection()
    {
        var swipeDirection = _endTouchPosition - _startTouchPosition;
        if (swipeDirection.magnitude < _minSwipeDistance)
        {
            Debug.Log("Too short swipe");
            return;
        }

        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x > 0)
            {
                OnSwipeRight.Invoke();
            }
            else
            {
                OnSwipeLeft.Invoke();
            }
        }

        else if (Mathf.Abs(swipeDirection.x) < Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.y > 0)
            {
                OnSwipeUp.Invoke();
            }
            else
            {
                OnSwipeDown.Invoke();
            }
        }
    }
}