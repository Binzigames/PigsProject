using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnZ = 30f;
    public float spawnInterval = 2f;

    float timer;

    private void Start()
    {
        Spawn();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        int index = Random.Range(0, prefabs.Length);

        Vector3 pos = new Vector3(0, 0, spawnZ);

        Instantiate(prefabs[index], pos, Quaternion.identity);
    }
}
