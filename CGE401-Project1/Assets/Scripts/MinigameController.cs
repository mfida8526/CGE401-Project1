using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI; // For the Button component
/*
* Mimi Davis
* Project1
* Game Manager for cookie clicker like minigame
*/


public class MinigameController : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public Button mashButton;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;

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
    }

    void EndGame(bool won)
    {
        gameActive = false;
        mashButton.interactable = false; // Disable the button

        if (won)
        {
            timerText.text = "You Win!\n Press the X button to exit!";
        }
        else
        {
            timerText.text = "Time's Up!\n Press the X button to try again!";
        }
    }
}

