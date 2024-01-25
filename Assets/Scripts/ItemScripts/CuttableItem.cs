using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableItem : Item
{
    [SerializeField] protected Item cuttedItem;

    public Item CuttedItem()
    {
        return cuttedItem;
    }
}
