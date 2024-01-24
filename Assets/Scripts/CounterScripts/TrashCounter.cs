using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : ClearCounter
{
    protected override void OnPlayerHasItemCounterHasNoItem()
    {
        Debug.Log("Ich werde zerst�rt");
        Transform item = ItemManager.Instance.TransferKitchenObjectFromPlayerToCounter();
        Destroy(item.gameObject);
    }
}
