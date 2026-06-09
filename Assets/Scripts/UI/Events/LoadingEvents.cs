using System;
using Cysharp.Threading.Tasks;

public class LoadingEvents
{
    public static Action OnShowLoadingScreen;
    public static Action OnHideLoadingScreen;
    public static Action<float> OnChangedProgress;
}
