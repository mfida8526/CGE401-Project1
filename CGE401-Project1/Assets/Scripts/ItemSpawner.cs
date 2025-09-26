using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;  // Assign prefabs in Inspector
    public Vector2 spawnAreaMin;      // Bottom-left corner of spawn area
    public Vector2 spawnAreaMax;      // Top-right corner of spawn area

    void Start()
    {
        foreach (GameObject prefab in itemPrefabs)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Vector3 spawnPos = new Vector3(randomPos.x, randomPos.y, 0f); // Ensure Z = 0
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
