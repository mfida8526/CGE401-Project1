using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public GameObject exitButton;
    public GameObject minigamePrefabInstance; // assign the actual prefab instance root here



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
                exitButton.SetActive(false);
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
        exitButton.SetActive(false);
    }

    void EndGame(bool win)
    {
        timerRunning = false;
        statusText.text = win ? "You Win! \n Press X to Exit" : "Time's Up! Press R to Restart";
        exitButton.SetActive(true);
    }

    public void ExitMinigame()
    {
        if (minigamePrefabInstance != null)
            minigamePrefabInstance.SetActive(false);
    }

}
