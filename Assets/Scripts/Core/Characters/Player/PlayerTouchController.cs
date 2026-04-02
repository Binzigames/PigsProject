using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerTouchController : MonoBehaviour
{
    [SerializeField] private float _minSwipeDistance = 50f;

    private readonly InputSystem _inputSystem;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    public event Action OnSwipeRight;
    public event Action OnSwipeLeft;
    public event Action OnSwipeUp;
    public event Action OnSwipeDown;

    private void Awake()
    {
        InputSystem _inputSystem = new();
        _inputSystem.Gameplay.Enable();
        
        _inputSystem.Gameplay.TouchScreenPress.started += OnTouchPress;
        _inputSystem.Gameplay.TouchScreenPress.canceled += OnTouchPress;
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