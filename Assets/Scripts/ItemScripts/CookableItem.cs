using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableItem : MonoBehaviour
{
    [SerializeField] protected Item cookedItem;

    public Item CookedItem()
    {
        return cookedItem;
    }
}
