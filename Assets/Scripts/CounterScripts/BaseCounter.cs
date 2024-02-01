using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCounter : CounterObject
{
    [SerializeField] protected Transform counterItemHolder;
    [SerializeField] protected Item ingredient = null;

    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.HasKitchenObject())
        {
            if (CheckIfCanReceive())
            {
                OnBothHaveItems();
            }
            else
            {

                OnCounterReceivesItem();
            }
        }
        else
        {
            if (ingredient == null)
            {
                OnNoneHaveItems();
            }
            else 
            {
                OnPlayerReceivesItem();

            }

        }

    }

    protected virtual void OnBothHaveItems()
    {
        if(ItemManager.Instance.GetKitchenObject() == Item.E_ItemIdentifier.Plate)
        Debug.Log("Player and Counter have an Item.");
    }

    protected virtual void OnNoneHaveItems()
    {
        Debug.Log("Player and Counter do not have an Item.");
    }

    protected virtual void OnCounterReceivesItem()
    {
        // Player Has Item And Counter Has No Item
        Transform item = ItemManager.Instance.TransferKitchenObjectFromPlayerToCounter();

        if (ingredient != null)
        {
            Plate plate = ingredient.GetComponent<Plate>();
            if (!plate.PutItemOnPlate(item.GetComponent<Item>()))
            {
                ItemManager.Instance.TransferSpecificKitchenObjectToPlayer(item);
            }
            
            return;
        }
        // Set Item to Counter's ItemHolder
        item.SetParent(counterItemHolder.transform);
        item.position = counterItemHolder.transform.position;
        item.rotation = counterItemHolder.transform.rotation;
        ingredient = item.GetComponent<Item>();
    }

    protected virtual void OnPlayerReceivesItem()
    {
        // Player receives Item from Counter
        ItemManager.Instance.TransferKitchenObjectFromCounterToPlayer(counterItemHolder);
        ingredient = null;
    }

    protected virtual bool CheckIfCanReceive()
    {
        // return false => CounterReceivesItem
        // return true => BothHaveItems
        if (ingredient == null)
        {
            return false;
        }

        if (ingredient.itemType == Item.E_ItemIdentifier.Plate)
        {
            return false;
        }

        return ingredient != null;
    }
}
