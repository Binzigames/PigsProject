using UnityEngine;
using Zenject;

public class CurrencyItem : Item
{
    [Inject] private readonly ICurrencyManager _currencyManager;
    [SerializeField] private int _value = 1;

    public override void Collect()
    {
        _currencyManager.AddCurrency(_value);
    }
}