using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ProcessingCounter
{
    private void Update()
    {
        ProcessItem();
        IsProcessing();
    }

    protected override void ProcessItem()
    {
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

    protected override bool IsProcessing()
    {
        return base.IsProcessing();
    }
}
