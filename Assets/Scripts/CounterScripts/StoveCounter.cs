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
        if (ItemToProcess is not CookableItem)
        {
            BurnWarning.UpdateWarningStatus(false);
            return;
        }

        ItemToProcess = Ingredient.GetComponent<CookableItem>();
        if (Ingredient.itemType == Item.E_ItemIdentifier.MeatPattyCooked)
        {
            BurnWarning.UpdateWarningStatus(true);
        }
        base.ProcessItem();
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
        base.OnPlayerReceivesItem();
        BurnWarning.UpdateWarningStatus(false);
    }

    protected override bool IsProcessing()
    {
        return base.IsProcessing();
    }
}
