using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
/*
* Mimi Davis
* Project1
* Game Manager for mashing-like minigame with a timer 
*/

public class MinigameController : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public Button mashButton;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;
    public List<MashButton> allItems;
    public SliderManager sliderBarManager;
    // Game parameters
    public float timeLimit = 10f; // 10 seconds
    public int winCount = 50; // Mash the button 50 times to win

    // Internal state variables
    private int mashCount = 0;
    private float currentTime;
    private bool gameActive = false;
    
    void Start()
    {
        // Add a listener to the button's OnClick event
        mashButton.onClick.AddListener(OnMash);
        ResetGame();
    }

    void Update()
    {
        if (!gameActive)
        {
            return;
        }

        // Decrease the timer
        currentTime -= Time.deltaTime;

        // Update the timer text
        timerText.text = $"Time Left: {Mathf.Max(0, currentTime):F2}";

        // Check for win/loss conditions
        if (mashCount >= winCount)
        {
            EndGame(true); // Player wins
        }
        else if (currentTime <= 0)
        {
            EndGame(false); // Player loses (time ran out)
        }
    }

    void StartMinigame()
    {
        
        foreach (MashButton item in allItems)
        {
            item.ResetItem(); // Ensure all items are visible
        }   
    }

    void OnMash()
    {
        if (gameActive)
        {
            mashCount++;
            counterText.text = $"Clicks: {mashCount}/{winCount}";
        }
    }

    void ResetGame()
    {
        gameActive = true;
        mashCount = 0;
        currentTime = timeLimit;

        // Update UI at the start
        counterText.text = $"Clicks: 0/{winCount}";
        timerText.text = $"Time Left: {timeLimit:F2}";

        // Make sure the button is interactable
        mashButton.interactable = true;
        StartMinigame();
    }

    void EndGame(bool won)
    {
        mashButton.interactable = false; // Disable the button

        if (won)
        {
            gameActive = false;
            timerText.text = "You Win!\n Press the X button to exit!";

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
            timerText.text = "Time's Up!\n Press the R to retry!";

            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }
        }
    }
}

