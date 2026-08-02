using UnityEngine.InputSystem;

public class InputManager : IInputActionProvider
{
    private readonly InputSystem _inputSystem;
    public InputManager()
    {
        _inputSystem = new InputSystem();
    }

    public InputAction GetInputAction(string actionID)
    {
        return _inputSystem.asset.FindAction(actionID);
    }

    public InputActionMap GetInputActionMap(string mapID)
    {
        return _inputSystem.asset.FindActionMap(mapID);
    }
}
