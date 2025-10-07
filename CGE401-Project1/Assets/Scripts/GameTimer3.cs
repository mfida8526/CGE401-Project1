using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
* Mimi Davis
* Project1
* Game Manager for clickable minigame, has a timer and resets minigame
*/

public class GameTimer3 : MonoBehaviour
{
    
    
    public float timeLimit = 10f; // Time limit for the minigame
    private float currentTime;
    private bool gameActive = false;
    public TextMeshProUGUI timerText;
    public SliderManager sliderBarManager;
    public List<ClickableItem> allItems; // Assign all your clickable items here in the Inspector

    void OnEnable()
    {
        ClickableItem.OnItemClicked += HandleItemClicked;
    }

    void OnDisable()
    {
        ClickableItem.OnItemClicked -= HandleItemClicked;
    }

    void Start()
    {
        StartMinigame();
    }

    void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            timerText.text = $"Time Left: {Mathf.Max(0, currentTime):F2}";
            if (currentTime <= 0)
            {
                EndMinigame(false); // Time ran out
            }
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartMinigame();
        }
    }

    void StartMinigame()
    {
        currentTime = timeLimit;
        gameActive = true;
        foreach (ClickableItem item in allItems)
        {
            item.ResetItem(); // Ensure all items are visible
        }

          
        
    }

    void HandleItemClicked(GameObject clickedItem)
    {
        // Logic for checking if all items are clicked, etc.
        
        bool allClicked = true;
        foreach (ClickableItem item in allItems)
        {
            if (item.gameObject.activeSelf)
            {
                allClicked = false;
                break;
            }
        }

        if (allClicked)
        {
            EndMinigame(true); // All items clicked
        }
    }

    void EndMinigame(bool win)
    {
        gameActive = false;
        if (win)
        {
            
            timerText.text = "You Win!\n Press the X to exit the minigame!";
            if (sliderBarManager != null)
            {
                sliderBarManager.MinigameWon();
            }
            else
            {
                Debug.LogError("Progress Bar Manager is not assigned in the Inspector of MinigameController!");
            }
        }
        else
        {
            timerText.text = "You Lose!\n Press R to retry!";
        }
        
    }

    void RestartMinigame()
    {
        Debug.Log("Restarting Minigame...");
        timerText.text = $"Time Left: {timeLimit:F2}";

        StartMinigame();
    }
}
