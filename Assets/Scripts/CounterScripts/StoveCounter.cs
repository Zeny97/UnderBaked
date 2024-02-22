using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : ProcessingCounter
{
    [SerializeField] private BurnWarningTemplateUI BurnWarning;
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
            BurnWarning.UpdateWarningStatus(ItemToProcess);
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

    protected override void OnPlayerReceivesItem()
    {
        BurnWarning.UpdateWarningStatus(ItemToProcess);
        base.OnPlayerReceivesItem();
    }

    protected override bool IsProcessing()
    {
        return base.IsProcessing();
    }
}
