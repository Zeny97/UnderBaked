using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ProcessingCounter
{
    [SerializeField] private ScriptableEvent OnCuttingIngredient;
    private float cuttingAudioCooldown = 0.2f;
    private float cuttingAudioTimer = 0;

    private void Update()
    {
        ProcessItem();
        IsProcessing();
    }

    protected override void ProcessItem()
    {
        // Only process cuttable items
        if (ItemToProcess is CuttableItem)
        {
            // plays cutting audio on set delay
            cuttingAudioTimer -= Time.deltaTime;
            if (cuttingAudioTimer <= 0)
            {
                OnCuttingIngredient.RaiseEvent();
                cuttingAudioTimer = cuttingAudioCooldown;
            }
            // Sets the Item thats going to get cut
            ItemToProcess = Item.GetComponent<CuttableItem>();
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
