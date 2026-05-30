using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour, ICurrencyManager
{
    private int _totalCurrency = 0;
    public int TotalCurrency => _totalCurrency;
    
    public event Action<int> OnCollectedCurrency;

    public void AddCurrency(int value)
    {
        _totalCurrency += value;
        OnCollectedCurrency?.Invoke(_totalCurrency);
    }

    public void ResetCurrency()
    {
        _totalCurrency = 0;
    }
}
