using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer3 : MonoBehaviour
{
    public float maxTime = 30f;
    public Text timerText; // Assign in Inspector
    public int maxFood;

    public List<Image> ClickableObject;
    private float timeRemaining;
    private bool timerIsRunning = false;
    public ClickableItem clickableItem;
   

    void Start()
    {
        timeRemaining = maxTime;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining).ToString();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.text = "Time's up!\n Press R to retry!'";
                Debug.Log("Game Over - Time Ran Out!");
                // Trigger game over logic here
            }
        }

        if (!timerIsRunning && timerText.text.Contains("Press R"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartNewGame();
            }
        }
    }
    
    public void AddMaxFood()
    {
        maxFood++;
    }

    void StartNewGame()
    {
        timeRemaining = maxTime;
        timerIsRunning = true;
        timerText.text = "";
        AddMaxFood();
        clickableItem.RespawnItem();
    }

    public bool IsTimerRunning()
    {
        return timerIsRunning;
    }
}
