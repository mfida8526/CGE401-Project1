using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class MinigameManager : MonoBehaviour
{
     public GameObject minigamePrefab;
    private GameObject currentMinigame;
    public Transform minigamePanelParent;

    public void LaunchMinigame()
    {
        if (currentMinigame != null) return;

        //currentMinigame = Instantiate(minigamePrefab, minigamePanelParent);
        currentMinigame = Instantiate(minigamePrefab); // No parent
        currentMinigame.GetComponent<SortingGameManager>().OnMinigameComplete += HandleMinigameEnd;
        // Pause the main game (optional)
        Time.timeScale = 0f;
    }

    private void HandleMinigameEnd(bool success)
    {
        // Resume the main game
        Time.timeScale = 1f;

        // Clean up minigame
        Destroy(currentMinigame);
        currentMinigame = null;

        if (success)
        {
            Debug.Log("Minigame Completed Successfully!");
            // Reward player or continue main game
        }
        else
        {
            Debug.Log("Minigame Failed.");
            // Maybe penalize or allow retry
        }
    }
}*/
