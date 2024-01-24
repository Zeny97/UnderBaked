using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool isCuttable;
    [SerializeField] private bool isCookable;
    [SerializeField] private E_ItemIdentifier itemType;

    public bool IsCookable { get => isCookable; }
    public bool IsCuttable { get => isCuttable; }

    public enum E_ItemIdentifier
    {
        Bread = 1,
        MeatPattyUncooked,
        MeatPattyCooked,
        MeatPattyBurned,
        Cabbage,
        CabbageSliced,
        CheeseBlock,
        CheeseSlices,
        Tomato,
        TomatoSlices,
        Plate,
    }
}