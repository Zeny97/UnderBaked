using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessableItem : Item
{
    // every processable item gets an own processing time
    // every processable item has a resulting item, which the proccessable item turns into once processed
    public float processingTime;

    [SerializeField] public Item ResultingItem;

    public Item ProcessedInto()
    {
        // once an item is finished processing, this method gets called to determine the item thats replacing the processed item
        return ResultingItem;
    }
}
