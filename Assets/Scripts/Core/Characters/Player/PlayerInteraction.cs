using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const string ITEM_TAG = "Item";
    public event Action OnItemCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ITEM_TAG))
        {
            other.TryGetComponent<Item>(out Item item);
            item.Collect();
            OnItemCollected?.Invoke();
        }
    }
}
