using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : CounterObject
{
    [SerializeField] protected Transform counterItemHolder;
    [SerializeField] protected Item ingredient = null;
    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.HasKitchenObject())
        {
            if (ingredient != null)
            {
                OnPlayerHasItemCounterHasItem();
            }
            else
            {
                OnPlayerHasItemCounterHasNoItem();
            }
        }
        else
        {
            if (!ingredient)
            {
                OnPlayerHasNoItemCounterHasNoItem();
            }
            else 
            {
                OnPlayerHasNoItemCounterHasItem();

            }

        }

    }

    protected virtual void OnPlayerHasItemCounterHasItem()
    {
        Debug.Log("Player and Counter have an Item.");
    }
    protected virtual void OnPlayerHasItemCounterHasNoItem()
    {
        Transform item = ItemManager.Instance.TransferKitchenObjectFromPlayerToCounter();
        // Player Has Item And Counter Has No Item

        // Transfer the item to the other object's ItemHolder
        item.SetParent(counterItemHolder.transform);
        item.position = counterItemHolder.transform.position;
        ingredient = item.GetComponent<Item>();
    }
    protected virtual void OnPlayerHasNoItemCounterHasNoItem()
    {
        Debug.Log("Player and Counter do not have an Item.");
    }
    protected virtual void OnPlayerHasNoItemCounterHasItem()
    {
        // Player receives Item from Counter
        ItemManager.Instance.TransferKitchenObjectFromCounterToPlayer(counterItemHolder);
        ingredient = null;
    }


}
