using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortingGameManager : MonoBehaviour
{
    public ItemSpawner itemSpawner;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;

    public float timeLimit = 30f;
    private float currentTime;
    private bool timerRunning = false;
    private int itemsSorted = 0;

    private int totalItemsToSort;


    void Start()
    {
        StartNewGame();
    }

    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime, 0, timeLimit);
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime);

            if (currentTime <= 0)
            {
                EndGame(false);
            }
        }

        if (!timerRunning && statusText.text.Contains("Press R"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartNewGame();
            }
        }
    }

    public void ItemSortedCorrectly()
    {
        itemsSorted++;

        if (itemsSorted >= totalItemsToSort)
        {
            EndGame(true);
        }
    }

    void StartNewGame()
    {
        itemsSorted = 0;
        currentTime = timeLimit;
        timerRunning = true;
        statusText.text = "";

        itemSpawner.SpawnFoodItems();
        totalItemsToSort = itemSpawner.spawnedItems.Count;
    }

    void EndGame(bool win)
    {
        timerRunning = false;
        statusText.text = win ? "You Win!" : "Time's Up! Press R to Restart";
    }
}
