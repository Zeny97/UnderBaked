using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ProcessingCounter : BaseCounter
{
    [SerializeField] protected ProgressbarTemplateUI ProgressBar;
    [SerializeField] protected ProcessableItem ItemToProcess;
    [SerializeField] protected Item ResultingItem;
    [SerializeField] protected float CurrentProcessingTime;

    private void Start()
    {
        // show progressbar only when item is being processed
        ProgressBar.transform.gameObject.SetActive(false);
    }

    protected virtual void ProcessItem()
    {
        // Check if Processable Item exists
        if (ItemToProcess != null)
        {
            // Show Progressbar and Update its fillamount according to its processingtime
            ProgressBar.transform.gameObject.SetActive(true);
            ProgressBar.UpdateProgressBar(CurrentProcessingTime, ItemToProcess.processingTime);
            if (CurrentProcessingTime < ItemToProcess.processingTime)
            {
                CurrentProcessingTime += Time.deltaTime;
                if (CurrentProcessingTime >= ItemToProcess.processingTime)
                {
                    // Processing is finished -> deactivate Progressbar
                    OnFinishedProcessingItem();
                    ProgressBar.transform.gameObject.SetActive(false);
                    CurrentProcessingTime = 0;
                }
            }
        }
    }

    protected virtual void OnFinishedProcessingItem()
    {
        // create finished item and set its location
        ResultingItem = Instantiate(ItemToProcess.ProcessedInto());
        ResultingItem.transform.SetParent(Item.transform.parent);
        ResultingItem.transform.position = Item.transform.position;
        ResultingItem.transform.rotation = Item.transform.rotation;

        // destroy old item
        Destroy(Item.gameObject);

        // fill item slot
        Item = ResultingItem.GetComponent<Item>();
    }

    protected override void OnCounterReceivesItem()
    {
        // In addition to the counter receiving the item, it checks if the item can be processed
        base.OnCounterReceivesItem();
        ItemToProcess = Item.GetComponent<ProcessableItem>();
    }

    protected override void OnPlayerReceivesItem()
    {
        // if player receives item, while item is still being processed, deactivate progressbar and set ItemToProcess to null
        // Processingprogress is not saved, so item has to be processed again
        if (IsProcessing())
        {
            CurrentProcessingTime = 0;
            ProgressBar.transform.gameObject.SetActive(false);
            ItemToProcess = null;
        }
        base.OnPlayerReceivesItem();
    }

    protected virtual bool IsProcessing()
    {
        if (CurrentProcessingTime > 0 && CurrentProcessingTime < ItemToProcess.processingTime)
        {
            return true;
        }
        return false;
    }
}
