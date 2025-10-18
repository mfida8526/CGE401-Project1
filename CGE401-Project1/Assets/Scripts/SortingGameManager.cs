using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
* Maile Fidale
* Project1
* manages win and lose conditions for sorting minigame
*/

public class SortingGameManager : MonoBehaviour
{
    public ItemSpawner itemSpawner;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;
    public Text tutorialText;

    public float timeLimit = 30f;
    private float currentTime;
    private bool timerRunning = false;
    private int itemsSorted = 0;
    public SliderManager sliderBarManager;

    private int totalItemsToSort;
    public GameObject exitButton;
    public GameObject minigamePrefabInstance; // assign the actual prefab instance root here

    void Start()
    {
        StartNewGame();

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.unscaledDeltaTime;
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
            
            if (sliderBarManager != null)
            {
                sliderBarManager.MinigameWon();
            }
            else
            {
                Debug.LogError("Progress Bar Manager is not assigned in the Inspector of MinigameController!");
            }
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
        statusText.text = win ? "You Win! \n Click X to Exit" : "Time's Up! Press R to Restart";
        exitButton.SetActive(true);
    }

    public void ExitMinigame()
    {
        Time.timeScale = 1f;

        if (minigamePrefabInstance != null)
            minigamePrefabInstance.SetActive(false);
    }

}
