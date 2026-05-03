using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int _totalCurrency = 0;
    
    public event Action<int> OnCollectedCurrency;

    public void AddCurrency(int value)
    {
        _totalCurrency += value;
        OnCollectedCurrency?.Invoke(value);
        Debug.Log(_totalCurrency);
    }
}
