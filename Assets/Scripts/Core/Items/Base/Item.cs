using UnityEngine;


public abstract class Item : MonoBehaviour, ICollectable
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            gameObject.SetActive(false);
        }
    }
    public virtual void Collect() { }
}
