using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/*
* Mimi Davis
* Project1
* Food items that open minigame panels
*/
public class FoodTrigger2 : MonoBehaviour
{
    
    public GameObject mashingMinigame;
    
    
    void Start()
    {
        mashingMinigame.GetComponent<MinigameController>();
        mashingMinigame.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (mashingMinigame != null)
            {
                mashingMinigame.SetActive(true);
                Interact();
            }
            else
            {
                mashingMinigame.SetActive(false);
            }
        }
    }

    private void Interact()
    {
        mashingMinigame.SetActive(true);
    }
}
