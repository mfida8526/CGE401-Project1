using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this if you are using TextMeshPro


public class MinigameController : MonoBehaviour
{
    // Assign these in the Inspector
    public TextMeshProUGUI timerText; // or public Text timerText;
    public TextMeshProUGUI clicksText; // or public Text clicksText;
    public GameObject clickableObject;
    public GameObject uIPanel;

    // Game settings
    public float timeLimit = 10f;
    public int clicksToWin = 10;

    // Internal game state variables
    private int clickCount = 0;
    private float currentTime;
    private bool gameActive = false;

    void Start()
    {
        currentTime = timeLimit;
        UpdateUI();
        gameActive = true;
    }

    void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();

            if (currentTime <= 0)
            {
                LoseGame();
            }
        }
    }

    // This function can be called by the clickable object
    public void OnClickObject()
    {
        if (gameActive)
        {
            clickCount++;
            UpdateUI();
            if (clickCount >= clicksToWin)
            {
                WinGame();
            }
        }
    }

    void UpdateUI()
    {
        // Update timer display
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Floor(currentTime)).ToString();

        // Update click count display
        clicksText.text = "Clicks: " + clickCount.ToString() + " / " + clicksToWin.ToString();
    }

    void WinGame()
    {
        gameActive = false;
        // Display a win message
        Debug.Log("You win!");
        timerText.text = "You win! \n Press the X to leave the minigame!";
        // You can also display a dedicated win panel here
    }

    void LoseGame()
    {
        gameActive = false;
        // Display a lose message
        Debug.Log("Time's up! You lose.");
        timerText.text = "Time's up! \n Press R to restart!";
        // You can display a game-over panel here
    }

    // Optional: a function to restart the game
    public void RestartGame()
    {
        uIPanel.SetActive(false);
    }
}

