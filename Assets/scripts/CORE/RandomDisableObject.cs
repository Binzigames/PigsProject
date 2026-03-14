using UnityEngine;

public class RandomDisableObject : MonoBehaviour
{
    [Range(0f, 1f)]
    public float disableChance = 0.5f;

    void Start()
    {
        if (Random.value < disableChance)
        {
            gameObject.SetActive(false);
        }
    }
}
