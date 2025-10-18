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
  public Slider progressBar;
  private int currentProgress = 0; // Tracks the current progress value
  public GameObject invisWall;

    public GameObject packageButton;
  
  
     // Call this method when a minigame is won
     public void MinigameWon()
     {
        currentProgress++; // Increment progress by one unit
        UpdateProgressBar();
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

                if (packageButton != null)
                {
                    packageButton.SetActive(true); // Show the package button
                }
                     Destroy(invisWall.gameObject);
                }
            }
            else
            {
                Debug.LogError("Progress Bar Slider is not assigned in the Inspector!");
            }
        }


        void Start()
        {
            UpdateProgressBar();
        if (packageButton != null)
            packageButton.SetActive(false); // Hide by default
    }     
}
