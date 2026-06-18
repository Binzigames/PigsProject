using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKeyboardController : MonoBehaviour
{
    private const string KEYBOARD_MOVE_ACTION_NAME = "Move";
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public event Action OnMoveRight;
    public event Action OnMoveLeft;
    public event Action OnMoveUp;
    public event Action OnMoveDown;

    private void Awake()
    {
        _playerInput = _playerInput ? _playerInput : GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions[KEYBOARD_MOVE_ACTION_NAME];
        _moveAction.performed += HandleMove;
    }

    private void OnDestroy()
    {
        _moveAction.performed -= HandleMove;
    }

    private void HandleMove(InputAction.CallbackContext ctx)
    {
        var moveDirection = _moveAction.ReadValue<Vector2>();

        if (moveDirection.x > 0)
        {
            OnMoveRight?.Invoke();
        }
        else
        {
            OnMoveLeft?.Invoke();
        }

        if (moveDirection.y > 0)
        {
            OnMoveUp?.Invoke();
        }
        else
        {
            OnMoveDown?.Invoke();
        }
    }
}
