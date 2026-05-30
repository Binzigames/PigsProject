using System;

namespace Scripts.UI.Events
{
    public static class ResultScreenEvents
    {
        public static Action OnContinueButtonPressed;
        public static Action<int> OnScoreResult;
        public static Action<int> OnShowBestScore;
        public static Action<int> OnCurrencyResult;
    }
}