using System;

public interface IUnityLifecycleEventListener
{
    public event Action<bool> OnApplicationFocusCallback;
    public event Action<bool> OnApplicationPauseCallback;
    public event Action OnApplicationQuitCallback;
}
