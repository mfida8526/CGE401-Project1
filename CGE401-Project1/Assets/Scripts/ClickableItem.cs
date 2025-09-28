using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableItem : MonoBehaviour, IPointerClickHandler
{
    private GameTimer3 gameTimer; // Reference to your timer script

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer3>(); // Find the timer in the scene
    }


    // For 2D objects with Colliders and EventSystem, or UI elements, you might use:
    public void OnPointerClick(PointerEventData eventData)
    {
       if (gameTimer != null && gameTimer.IsTimerRunning())
       {
            Debug.Log("Item Clicked before time ran out!");
            // Perform action, e.g., destroy item, add score
            Destroy(gameObject);
       }
       else
       {
            Debug.Log("Item clicked, but time has run out!");
       }
    }
}
