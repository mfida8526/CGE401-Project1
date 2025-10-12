using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;
/*
* Mimi Davis
* Project1
* Game manager for the typing minigame where you type the prompt given to you
*/
public class TypingMinigameManager : MonoBehaviour
{
    public TextMeshProUGUI promptText; 
    public TMP_InputField inputField; 
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI gameOverText; 

    public float gameDuration = 10f; 
    private float currentTime;
    private string currentPrompt;
    private bool gameActive = false;
    public SliderManager sliderBarManager;

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Max(0, Mathf.FloorToInt(currentTime)).ToString();

            if (currentTime <= 0)
            {
                EndGame(false); // Time ran out
            }

            if (Input.GetKeyDown(KeyCode.Return) && inputField.text == currentPrompt)
            {
                EndGame(true); // Player typed correctly
            }
        }

        if (!gameActive && Input.GetKeyDown(KeyCode.R))
        {
            InitializeGame(); // Restart the game
        }
    }

    void InitializeGame()
    {
        gameActive = true;
        currentTime = gameDuration;
        gameOverText.gameObject.SetActive(false);
        inputField.gameObject.SetActive(true);
        inputField.text = "";
        inputField.interactable = true;
        inputField.ActivateInputField(); // Focus the input field

        GenerateNewPrompt();
    }

    void GenerateNewPrompt()
    {
        // Example: Replace with your prompt generation logic
        string[] prompts = { "pantry", "helpful", "delivery", "kitchen", "food", "resource" };
        currentPrompt = prompts[Random.Range(0, prompts.Length)];
        promptText.text = currentPrompt;
    }

    void EndGame(bool won)
    {
        gameActive = false;
        inputField.interactable = false;
        gameOverText.gameObject.SetActive(true);

        if (won)
        {
            gameOverText.text = "You Win!\nClick the X button to leave.";

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
            gameOverText.text = "Game Over!\nPress 'R' to restart.";
        }
    }
}
