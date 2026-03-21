using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right

    private Vector2 startTouch;
    private Vector2 endTouch;

    void Update()
    {
        HandleKeyboardInput();
        HandleSwipe();
        MoveToLane();
    }

    void MoveToLane()
    {
        float targetX = (currentLane - 1) * laneDistance;

        Vector3 targetPos = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            laneChangeSpeed * Time.deltaTime
        );
    }

    void HandleKeyboardInput()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
                MoveLeft();

            if (Keyboard.current.dKey.wasPressedThisFrame)
                MoveRight();
        }
    }

    void HandleSwipe()
    {
        if (Touchscreen.current == null) return;

        var touch = Touchscreen.current.primaryTouch;

        if (touch.press.wasPressedThisFrame)
        {
            startTouch = touch.position.ReadValue();
        }

        if (touch.press.wasReleasedThisFrame)
        {
            endTouch = touch.position.ReadValue();

            Vector2 swipe = endTouch - startTouch;

            if (swipe.magnitude < 50) return;

            swipe.Normalize();

            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            {
                if (swipe.x > 0)
                    MoveRight();
                else
                    MoveLeft();
            }
        }
    }

    void MoveLeft()
    {
        if (currentLane > 0)
            currentLane--;
    }

    void MoveRight()
    {
        if (currentLane < 2)
            currentLane++;
    }
}
