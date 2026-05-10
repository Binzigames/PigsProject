using System;

namespace Scripts.UI.Events
{
    public static class ResultScreenEvents
    {
        public static Action OnContinueButtonPressed;
        public static Action<string> OnScoreResult;
        public static Action<string> OnCurrencyResult;
    }
}