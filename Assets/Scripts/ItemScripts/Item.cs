using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public E_ItemIdentifier itemType;
    public Sprite itemSprite;

    public enum E_ItemIdentifier
    {
        Bread = 1,
        MeatPattyUncooked,
        MeatPattyCooked,
        MeatPattyBurned,
        Cabbage,
        CabbageSlices,
        CheeseBlock,
        CheeseSlices,
        Tomato,
        TomatoSlices,
        Plate,
    }
}