using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
* Mimi Davis
* Project1
* Makes player walk into trigger zone to get to get the win screen
*/
public class SceneTrigger3 : MonoBehaviour
{
    public GameObject winPanel;
    
    void Start()
    {
        winPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true);
                Interact();
            }
            else
            {
                winPanel.SetActive(false);
            }
        }
    }

    private void Interact()
    {
        winPanel.SetActive(true);
    }
}