using System;

public static class MainMenuEvents
{
    public static Action OnPlayButtonPressed;
    public static Action OnSettingButtonPressed;
    public static Action<int> OnShowedBestScore;
    public static Action<int> OnShowedTotalMoney;
}
