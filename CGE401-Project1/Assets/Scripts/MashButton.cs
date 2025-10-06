using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
* Mimi Davis
* Project1
* Code for reseting MashButton in Minigame controller
*/
public class MashButton : MonoBehaviour
{
    private Button itemButton;

    public void ResetItem()
    {
        gameObject.SetActive(true); // Make the item reappear for restart
    }
}
