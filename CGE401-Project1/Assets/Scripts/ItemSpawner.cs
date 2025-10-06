using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> foodPrefabs; // Assign your fruit and veggie prefabs
    public RectTransform spawnArea;
    public int spawnCount = 16;
    public SortingGameManager sortingGameManager;

    public List<GameObject> spawnedItems = new List<GameObject>();

    public void SpawnFoodItems()
    {
        // Clean up old items
        foreach (var item in spawnedItems)
        {
            if (item != null) Destroy(item);
        }
        spawnedItems.Clear();

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject prefab = foodPrefabs[Random.Range(0, foodPrefabs.Count)];
            GameObject item = Instantiate(prefab, spawnArea);
            item.transform.localScale = Vector3.one;

            RectTransform rt = item.GetComponent<RectTransform>();
            rt.anchoredPosition = GetRandomPositionInRect(spawnArea);

            DraggableItem draggable = item.GetComponent<DraggableItem>();
            if (draggable != null)
            {
                draggable.sortingGameManager = sortingGameManager;
            }

            spawnedItems.Add(item);
        }
    }

    Vector2 GetRandomPositionInRect(RectTransform rect)
    {
        Vector2 size = rect.rect.size;
        return new Vector2(
            Random.Range(-size.x / 2f, size.x / 2f),
            Random.Range(-size.y / 2f, size.y / 2f)
        );
    }
}
