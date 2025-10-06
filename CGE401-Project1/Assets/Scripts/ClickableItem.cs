using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/*
* Mimi Davis
* Project1
* Code for the item's you click on in clickable minigame
*/
public class ClickableItem : MonoBehaviour
{
    public delegate void ItemClickedAction(GameObject clickedItem);
    public static event ItemClickedAction OnItemClicked;

    private Button itemButton;

    void Awake()
    {
        itemButton = GetComponent<Button>();
        if (itemButton != null)
        {
            itemButton.onClick.AddListener(HandleClick);
        }
    }

    void HandleClick()
    {
        OnItemClicked?.Invoke(gameObject);
        gameObject.SetActive(false); // Make the item disappear
    }

    public void ResetItem()
    {
        gameObject.SetActive(true); // Make the item reappear for restart
    }
}
