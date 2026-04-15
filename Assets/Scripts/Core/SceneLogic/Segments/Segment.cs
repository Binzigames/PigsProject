using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Segment : MonoBehaviour
{
    [SerializeField] private List<CurrencyItem> _currencyItemList;
    public IObjectPool<Segment> SegmentPool { get; set; }

    private void OnEnable()
    {
        if (_currencyItemList != null)
        {
            ResetCurrencyItems();
        }
    }
    private void ResetCurrencyItems()
    {
        foreach (var currency in _currencyItemList)
        {
            currency.gameObject.SetActive(true);
        }
    }
}