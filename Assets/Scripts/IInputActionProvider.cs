using UnityEngine.InputSystem;

public interface IInputActionProvider
{
    public InputActionMap GetInputActionMap(string mapID);
    public InputAction GetInputAction(string actionID);
}
