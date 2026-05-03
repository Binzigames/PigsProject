using System;

public static class HUDEvents
{
    public static Action<int> OnChangedCurrency;
    public static Action<int> OnChangedScore;
    public static Action OnPausePressed;
}