using System;

public interface ICurrencyManager
{
    public int TotalCurrency { get; }

    public event Action<int> OnCollectedCurrency;
    
    public void AddCurrency(int value);
    public void ResetCurrency();
}
