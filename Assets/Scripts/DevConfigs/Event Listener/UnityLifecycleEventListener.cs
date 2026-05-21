using System;
using UnityEngine;

public class UnityLifecycleEventListener : MonoBehaviour, IUnityLifecycleEventListener
{
    public event Action<bool> OnApplicationFocusCallback;
    public event Action<bool> OnApplicationPauseCallback;
    public event Action OnApplicationQuitCallback;

    private void OnApplicationFocus(bool focus)
    {
        OnApplicationFocusCallback?.Invoke(focus);
    }

    private void OnApplicationPause(bool pause)
    {
        OnApplicationPauseCallback?.Invoke(pause);
    }

    private void OnApplicationQuit()
    {
        OnApplicationQuitCallback?.Invoke();
    }
}
