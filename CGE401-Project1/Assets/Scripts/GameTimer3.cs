using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer3 : MonoBehaviour
{
    public float maxTime = 30f;
    public Text timerText; // Assign in Inspector

    private float timeRemaining;
    private bool timerIsRunning = false;

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
                timerText.text = "Time's Up!";
                Debug.Log("Game Over - Time Ran Out!");
                // Trigger game over logic here
            }
        }
    }

    public bool IsTimerRunning()
    {
        return timerIsRunning;
    }
}
