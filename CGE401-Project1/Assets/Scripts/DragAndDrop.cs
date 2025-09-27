using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private SortingZone currentZone;
    private Vector3 initialPosition;

    void Start()
    {
        //initialPosition = transform.position;
        Vector3 pos = transform.position;
        initialPosition = new Vector3(pos.x, pos.y, 0f);  // Force Z = 0
        transform.position = initialPosition;  // Optional: Ensure object starts at this corrected position
    }

    void OnMouseDown()
    {
        isDragging = true;
        currentZone = null;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (currentZone != null)
        {
            Item item = GetComponent<Item>();
            if (item != null && item.itemType == currentZone.zoneType)
            {
                // Notify GameManager
                SortingGameManager gm = FindObjectOfType<SortingGameManager>();
                if (gm != null)
                {
                    gm.ItemSortedCorrectly();
                }
                else
                {
                    Debug.LogError("GameManager not found!");
                }

                Destroy(gameObject);  // Completely removes the object
                Debug.Log("Item placed correctly and destroyed!");
            }
        }
        else
        {
            ResetPosition();
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f) + offset;  // Keep Z = 0 while dragging
        }
    }

    void ResetPosition()
    {
        //transform.position = initialPosition;
        transform.position = new Vector3(initialPosition.x, initialPosition.y, 0f);
        currentZone = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SortingZone zone = collision.GetComponent<SortingZone>();
        if (zone != null)
        {
            currentZone = zone;
            Debug.Log("Entered zone: " + zone.name);  // ✅ Check if this logs!
            currentZone = zone;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SortingZone zone = collision.GetComponent<SortingZone>();
        if (zone != null && currentZone == zone)
        {
            currentZone = null;
            Debug.Log("Entered zone: " + zone.name);  // ✅ Check if this logs!
            currentZone = zone;
        }
    }
}
