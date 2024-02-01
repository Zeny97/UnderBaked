using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinableItem : Item
{
    [SerializeField] protected Item combinableItem;

    public Item CombinedItem()
    {
        return combinableItem; 
    }
}
