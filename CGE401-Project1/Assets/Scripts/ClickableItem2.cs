using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem2 : MonoBehaviour
{
    private MinigameController minigameController;

    void Start()
    {
        // Find the GameManager to get its script
        minigameController = FindObjectOfType<MinigameController>();
    }

    void OnMouseDown()
    {
        // Call the minigame controller's click function
        if (minigameController != null)
        {
            minigameController.OnClickObject();
        }
    }
}

