using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessableItem : Item
{

    public float processingTime;

    [SerializeField] public Item ResultingItem;

    public Item ProcessedInto()
    {
        return ResultingItem;
    }

}
