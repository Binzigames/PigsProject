using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const string ITEM_TAG = "Item";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ITEM_TAG))
        {
            other.TryGetComponent(out Item item);
            item.Collect();
        }
    }
}
