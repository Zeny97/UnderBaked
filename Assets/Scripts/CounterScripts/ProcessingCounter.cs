using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ProcessingCounter : BaseCounter
{
    [SerializeField] protected ProgressBar ProgressBar;
    [SerializeField] protected ProcessableItem ItemToProcess;
    [SerializeField] protected Item ResultingItem;
    [SerializeField] protected float CurrentProcessingTime;

    private void Start()
    {
        ProgressBar.transform.gameObject.SetActive(false);
    }

    protected virtual void ProcessItem()
    {
        if (ItemToProcess != null)
        {
            ProgressBar.transform.gameObject.SetActive(true);
            ProgressBar.UpdateProgressBar(CurrentProcessingTime, ItemToProcess.processingTime);
            if (CurrentProcessingTime < ItemToProcess.processingTime)
            {
                CurrentProcessingTime += Time.deltaTime;
                if (CurrentProcessingTime >= ItemToProcess.processingTime)
                {
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
        ResultingItem.transform.SetParent(Ingredient.transform.parent);
        ResultingItem.transform.position = Ingredient.transform.position;
        ResultingItem.transform.rotation = Ingredient.transform.rotation;

        // destroy old item
        Destroy(Ingredient.gameObject);

        // fill ingredient slot
        Ingredient = ResultingItem.GetComponent<Item>();
    }

    protected override void OnCounterReceivesItem()
    {
        base.OnCounterReceivesItem();
        ItemToProcess = Ingredient.GetComponent<ProcessableItem>();
    }

    protected override void OnPlayerReceivesItem()
    {
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
        if (CurrentProcessingTime> 0 && CurrentProcessingTime < ItemToProcess.processingTime)
        {
            return true;
        }
        return false;
    }
}
