using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCounter : CounterObject
{
    [SerializeField] private ScriptableEvent OnPickedSomething;
    [SerializeField] private ScriptableEvent OnDroppedSomething;
    [SerializeField] protected Transform CounterItemHolder;
    [SerializeField] protected Item Item = null;

    public override void InteractWithCounter()
    {
        // Checks through 4 scenarios
        // Player has item, Counter has item
        // Player has item, Counter has no item
        // Player has no item, Counter has item
        // Player has no item, Counter has no item

        if (ItemManager.Instance.PlayerHasKitchenObject())
        {
            if (HasKitchenObject())
            {
                OnBothHaveItems();
            }
            else
            {
                // plays sound clip
                OnDroppedSomething.RaiseEvent();
                OnCounterReceivesItem();
            }
        }
        else
        {
            if (Item == null)
            {
                OnNoneHaveItems();
            }
            else 
            {
                OnPlayerReceivesItem();
                // plays sound clip
                OnPickedSomething.RaiseEvent();
            }

        }

    }

    protected virtual void OnBothHaveItems()
    {
        // Player should be able to put items on the held plate if its combinable
        // Check if player has Plate
        // Check if counterobject is combinable
        // Put item on plate
        Debug.Log("Player and Counter have an Item.");
    }

    protected virtual void OnNoneHaveItems()
    {
        Debug.Log("Player and Counter do not have an Item.");
    }

    protected virtual void OnCounterReceivesItem()
    {
        // Player Has Item And Counter Has No Item
        Transform item = ItemManager.Instance.GetItemFromPlayer();

        if (Item != null)
        {
            // Check if playerheld item is a plate
            Plate plate = Item.GetComponent<Plate>();
            if (!plate.PutItemOnPlate(item.GetComponent<Item>()))
            {
                ItemManager.Instance.TransferSpecificItemToPlayer(item);
            }
            plate.UpdateVisual();
            return;
        }
        // Set Item to Counter's ItemHolder
        item.SetParent(CounterItemHolder.transform);
        item.position = CounterItemHolder.transform.position;
        item.rotation = CounterItemHolder.transform.rotation;
        Item = item.GetComponent<Item>();
    }

    protected virtual void OnPlayerReceivesItem()
    {
        // Player receives Item from Counter
        ItemManager.Instance.GetItemFromCounter(CounterItemHolder);
        Item = null;
    }

    protected virtual bool HasKitchenObject()
    {
        // player doesn't have item
        if (Item == null)
        {
            return false;
        }

        // Check if Item is => Plate 
        if (Item.itemType == Item.E_ItemIdentifier.Plate)
        {
            return false;
        }

        // return true => BothHaveItems
        return Item != null;
    }
}
