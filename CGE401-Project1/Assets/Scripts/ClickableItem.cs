using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableItem : MonoBehaviour, IPointerClickHandler
{
    public GameTimer3 gameTimer; // Reference to your timer script
    public float clickTimeLimit = 5f;
    public float respawnDelay = 3f;

    private float currentTimer;
    private bool isActive = true; 
    
        
    void Start()
    {
       GameTimer3 gameTimer = GetComponent<GameTimer3>();
    }

    void OnEnable()
    {
        currentTimer = clickTimeLimit;
        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                StartCoroutine(RespawnItem());
                isActive = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (isActive && currentTimer > 0)
        {
            StartCoroutine(RespawnItem());
            isActive = false;
        }
    }

    public IEnumerator RespawnItem()
    {
        gameObject.SetActive(false); // Hide the item
        yield return new WaitForSeconds(respawnDelay);// Wait for respawn delay
        gameObject.SetActive(true); // Show the item again
        // OnEnable will reset the timer automatically
    }


    // For 2D objects with Colliders and EventSystem, or UI elements, you might use:
    public void OnPointerClick(PointerEventData eventData)
    {
       if (gameTimer != null && gameTimer.IsTimerRunning())
       {
            Debug.Log("Item Clicked before time ran out!");
            // Perform action, e.g., destroy item, add score

           
       }
       else
       {
            Debug.Log("Item clicked, but time has run out!");
       }
    }
}
