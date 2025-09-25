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
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
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
                Destroy(gameObject);  // Completely removes the object

                Debug.Log("Item placed correctly and destroyed!");
            }
            else
            {
                Debug.Log("Wrong zone! Resetting position.");
                ResetPosition();
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
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SortingZone zone = collision.GetComponent<SortingZone>();
        if (zone != null)
        {
            currentZone = zone;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SortingZone zone = collision.GetComponent<SortingZone>();
        if (zone != null && currentZone == zone)
        {
            currentZone = null;
        }
    }
}
