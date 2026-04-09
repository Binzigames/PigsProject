using UnityEngine;


public abstract class Item : MonoBehaviour, ICollectable
{
    public virtual void Collect() { }
}
