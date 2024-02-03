using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : ProcessingCounter
{
    private void Update()
    {
        ProcessItem();
        IsProcessing();
    }

    protected override void ProcessItem()
    {
        // Check Item type
        if (ItemToProcess is CookableItem)
        {
            ItemToProcess = Ingredient.GetComponent<ProcessableItem>();
            base.ProcessItem();
        }
    }

    protected override void OnFinishedProcessingItem()
    {
        base.OnFinishedProcessingItem();
    }

    protected override void OnCounterReceivesItem()
    {
        base.OnCounterReceivesItem();
    }

    protected override bool IsProcessing()
    {
        return base.IsProcessing();
    }
}
