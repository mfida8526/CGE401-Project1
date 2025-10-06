using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

/*
* Mimi Davis
* Project1
* Slider for progression bar 
*/
public class SliderManager : MonoBehaviour
{
  public Slider progressBar; // Assign your UI Slider here in the Inspector
  private int currentProgress = 0; // Tracks the current progress value
  public GameObject invisWall;

     // Call this method when a minigame is won
     public void MinigameWon()
     {
        currentProgress++; // Increment progress by one unit
        UpdateProgressBar(); // Update the visual representation
     }   

       
   private void UpdateProgressBar()
        {
            if (progressBar != null)
            {
                progressBar.value = currentProgress;
               
                if (currentProgress >= progressBar.maxValue)
                {
                     Debug.Log("All minigames completed!");
                     //Press R to restart if game is over
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                     Destroy(invisWall.gameObject);
                    // Trigger end-game or reward logic
                }
            }
            else
            {
                Debug.LogError("Progress Bar Slider is not assigned in the Inspector!");
            }
        }

        // Optional: Initialize the progress bar at the start
        void Start()
        {
            UpdateProgressBar();
        }     
}
