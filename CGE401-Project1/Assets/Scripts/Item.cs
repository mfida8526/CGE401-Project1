using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType; // Set this in Inspector as Fruit or Vegetable
}

public enum ItemType
{
    Fruit,
    Vegetable
}
