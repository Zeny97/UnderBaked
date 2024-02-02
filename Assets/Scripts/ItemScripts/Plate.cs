using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plate : Item
{
    // private IDictionary<Item.E_ItemIdentifier, string> plateItems;
    [SerializeField] private int maxPlateItems;
    [SerializeField] private Item[] itemsOnPlate;
    [SerializeField] private int curPlateItemAmount;
    [SerializeField] private Transform itemHolder;

    private void Awake()
    {
        itemsOnPlate = new Item[maxPlateItems];
        curPlateItemAmount = 0;

        // plateItems = new Dictionary<Item.E_ItemIdentifier, string>();
        // plateItems.Add(Item.E_ItemIdentifier.Bread, "Bread");
        // plateItems.Add(Item.E_ItemIdentifier.MeatPattyCooked, "Meat Patty Cooked");
        // plateItems.Add(Item.E_ItemIdentifier.CabbageSliced, "Cabbage Sliced");
        // plateItems.Add(Item.E_ItemIdentifier.CheeseSlices, "Cheese Slices");
        // plateItems.Add(Item.E_ItemIdentifier.TomatoSlices, "Tomato Slices");
    }

    public bool PutItemOnPlate(Item item)
    {
        // Wenn Teller voll
        if(curPlateItemAmount >= maxPlateItems)
        {
            return false;
        }

        // Füge Item dem Teller hinzu
        itemsOnPlate[curPlateItemAmount] = item;
        curPlateItemAmount++;

        item.transform.SetParent(itemHolder);
        item.transform.position = itemHolder.transform.position;
        item.transform.rotation = itemHolder.transform.rotation;

        return true;
    }


}
