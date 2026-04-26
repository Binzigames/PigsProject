using System;

public static class SettingsEvents
{
    public static Action OnExitSettingsButton;
    public static Action<bool> OnSoundToggle;
    public static Action<bool> OnMusicToggle;
    public static Action<bool> OnHapticToggle;
}