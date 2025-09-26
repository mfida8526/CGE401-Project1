using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortingGameManager : MonoBehaviour
{
    public ItemSpawner itemSpawner;       // Assign in Inspector
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;

    public float timeLimit = 15f;
    private float currentTime;
    private bool timerRunning = true;
    private int itemsSorted = 0;

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
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();

            if (currentTime <= 0)
            {
                EndGame(false);  // Time ran out, player loses
            }
        }

        // Only listen for 'R' key to restart if game ended by losing
        if (!timerRunning && statusText.text.Contains("Press R"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartNewGame();
            }
        }
    }

    void StartNewGame()
    {
        currentTime = timeLimit;
        timerRunning = true;
        itemsSorted = 0;
        statusText.text = "";

        itemSpawner.SpawnItems();  // Spawn items using your ItemSpawner
    }

    public void ItemSortedCorrectly()
    {
        itemsSorted++;
        if (itemsSorted >= itemSpawner.itemPrefabs.Length)
        {
            EndGame(true);
        }
    }

    void EndGame(bool win)
    {
        timerRunning = false; // Stop the timer

        if (win)
        {
            statusText.text = "You Win!";
            // Optionally, disable dragging or show a "Play Again" button here
        }
        else
        {
            statusText.text = "Time's Up! Press R to Restart";
            // Disable dragging as before
        }

        foreach (var drag in FindObjectsOfType<DragAndDrop>())
        {
            drag.enabled = false; // disable dragging after game ends
        }
    }
}
