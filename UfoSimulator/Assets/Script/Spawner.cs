using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ufoPrefabs;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 6f;
    public int minUfoStart = 3;
    public int maxUfoStart = 6;
    public int maxUfos = 30;
    public Vector2 boardSize = new Vector2(10f, 10f);
    private bool stopspawning = false;

    void Start()
    {
        SpawnUfo(Random.Range(minUfoStart, maxUfoStart));
        InvokeRepeating("SpawnInvokeUfo", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));
    }

    void Update()
    {

        if (transform.childCount >= maxUfos)
        {
            stopspawning = true;
        }
        else
        {
            stopspawning = false;
        }
    }

    void SpawnInvokeUfo()
    {
        if (stopspawning == false)
        {
            SpawnUfo(1);
        }
    }

    void SpawnUfo(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(Random.Range(-boardSize.x, boardSize.x), 0f, Random.Range(-boardSize.y, boardSize.y));
            GameObject ufoPrefab = ufoPrefabs[Random.Range(0, ufoPrefabs.Length)];
            GameObject ufo = Instantiate(ufoPrefab, position, Quaternion.identity, transform);
        }
    }
}
