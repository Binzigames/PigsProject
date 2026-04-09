using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int _totalCurrency = 0;
    public void AddCurrency(int value)
    {
        _totalCurrency += value;
        Debug.Log(_totalCurrency);
    }
}
