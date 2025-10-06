using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum ItemType
{
    Fruit,
    Vegetable
}

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Transform originalParent;
    private Vector2 originalPosition;
    private Canvas canvas;

    public ItemType itemType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag started: " + gameObject.name);
        transform.SetParent(canvas.transform); // bring to front
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
            DropZone dropZone = r.gameObject.GetComponent<DropZone>();
            if (dropZone != null)
            {
                if (dropZone.acceptedType == itemType)
                {
                    droppedInCorrectZone = true;
                    break;
                }
            }
        }

        if (droppedInCorrectZone)
        {
            Debug.Log($"Dropped {itemType} in correct zone. Destroying {gameObject.name}");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Dropped {itemType} in wrong zone or no zone. Returning {gameObject.name}");
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
    }

}

