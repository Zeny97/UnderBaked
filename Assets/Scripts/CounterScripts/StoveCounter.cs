using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : ProcessingCounter
{
    [SerializeField] private BurnWarningTemplateUI BurnWarning;
    [SerializeField] private AudioSource audioSource;
    private bool isAudioPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ProcessItem();
        IsProcessing();
    }

    protected override void ProcessItem()
    {
        // Only processes cookable items
        if (ItemToProcess is not CookableItem)
        {
            // burned meat patty is not cookable, so Warning Icon should get deactivated
            BurnWarning.UpdateWarningStatus(false);
            return;
        }

        // activate sizzling sound
        if (!isAudioPlaying)
        {
            audioSource.Play();
            isAudioPlaying = true;
        }

        // Show warning icon if Meat Patty is Cooked
        if (Item.itemType == Item.E_ItemIdentifier.MeatPattyCooked)
        {
            BurnWarning.UpdateWarningStatus(true);
        }
        ItemToProcess = Item.GetComponent<CookableItem>();
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
        // stop sizzling sound and deactivate warning icon
        audioSource.Stop();
        isAudioPlaying = false;
        base.OnPlayerReceivesItem();
        BurnWarning.UpdateWarningStatus(false);
    }

    protected override bool IsProcessing()
    {
        return base.IsProcessing();
    }
}
