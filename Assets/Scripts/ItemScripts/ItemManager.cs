using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] private GameObject playerItemHolder;


    private void Awake()
    {
        if( Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public bool HasKitchenObject() 
    {
        // Check if Player has Ingredients
        if(playerItemHolder.transform.childCount != 0 )
            return true;
        return false;
    }

    public Item.E_ItemIdentifier GetKitchenObject()
    {
        return playerItemHolder.GetComponentInChildren<Item.E_ItemIdentifier>();
    }

    public Transform TransferKitchenObjectFromPlayerToCounter()
    {
        // Get the item from the player's ItemHolder
        Transform ingredient = playerItemHolder.transform.GetChild(0);
        ingredient.SetParent(null);
        return ingredient;

    }
    public void TransferItemFromCounterToPlayer(Transform _counterItemHolder)
    {
        // Get the item from the counter's ItemHolder
        Transform ingredient = _counterItemHolder.transform.GetChild(0);

        // Transfer the item to the player's ItemHolder
        ingredient.SetParent(playerItemHolder.transform);
        ingredient.position = playerItemHolder.transform.position;
    }

    public void TransferSpecificItemToPlayer(Transform ingredient)
    {
        ingredient.SetParent(playerItemHolder.transform);
        ingredient.position = playerItemHolder.transform.position;
    }
}
