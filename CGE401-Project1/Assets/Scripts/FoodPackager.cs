using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPackager : MonoBehaviour
{
    public GameObject boxPrefab;          // Assign in Inspector
    public Transform playerTransform;     // Assign player transform
    public Vector3 boxOffset = new Vector3(0, -1f, 0); // Position box below player

    private GameObject currentBox;

    // Called when the package button is clicked
    public void PackageFood()
    {
        if (currentBox == null)
        {
            currentBox = Instantiate(boxPrefab, playerTransform.position + boxOffset, Quaternion.identity);

            // Parent the box to the player so it follows movement
            currentBox.transform.SetParent(playerTransform);

            // (Optional) disable the package button so it can't be pressed again
            GameObject packageButton = GameObject.Find("PackageButton");
            if (packageButton != null)
            {
                packageButton.SetActive(false);
            }

            Debug.Log("Food packaged!");
        }
    }

    public bool HasBox()
    {
        return currentBox != null;
    }

    public void DeliverBox()
    {
        if (currentBox != null)
        {
            Destroy(currentBox);
            currentBox = null;
        }
    }
}
