using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableItem : Item
{
    [SerializeField] protected Item cookedItem;

    public Item CookedItem()
    {
        return cookedItem;
    }
}
