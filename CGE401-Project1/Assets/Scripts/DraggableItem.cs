using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
* Maile Fidale
* Project1
* allows player to drag and drop food items
*/

public enum ItemType
{
    Fruit,
    Vegetable
}

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemType itemType;
    public SortingGameManager sortingGameManager;

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Transform originalParent;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform); // Bring to front
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        bool droppedInCorrectZone = false;

        foreach (RaycastResult r in results)
        {
            DropZone dz = r.gameObject.GetComponent<DropZone>();
            if (dz != null && dz.acceptedType == itemType)
            {
                droppedInCorrectZone = true;
                sortingGameManager.ItemSortedCorrectly();
                break;
            }
        }

        if (droppedInCorrectZone)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}