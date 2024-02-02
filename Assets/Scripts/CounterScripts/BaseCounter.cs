using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCounter : CounterObject
{
    [SerializeField] protected Transform CounterItemHolder;
    [SerializeField] protected Item Ingredient = null;

    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.PlayerHasKitchenObject())
        {
            if (HasKitchenObject())
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
            if (Ingredient == null)
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

        if (Ingredient != null)
        {
            Plate plate = Ingredient.GetComponent<Plate>();
            if (!plate.PutItemOnPlate(item.GetComponent<Item>()))
            {
                ItemManager.Instance.TransferSpecificItemToPlayer(item);
            }
            
            return;
        }
        // Set Item to Counter's ItemHolder
        item.SetParent(CounterItemHolder.transform);
        item.position = CounterItemHolder.transform.position;
        item.rotation = CounterItemHolder.transform.rotation;
        Ingredient = item.GetComponent<Item>();
    }

    protected virtual void OnPlayerReceivesItem()
    {
        // Player receives Item from Counter
        ItemManager.Instance.TransferItemFromCounterToPlayer(CounterItemHolder);
        Ingredient = null;
    }

    protected virtual bool HasKitchenObject()
    {
        // return false
        if (Ingredient == null)
        {
            return false;
        }

        // Check if Item is => Plate 
        if (Ingredient.itemType == Item.E_ItemIdentifier.Plate)
        {
            return false;
        }

        // return true => BothHaveItems
        return Ingredient != null;
    }
}
