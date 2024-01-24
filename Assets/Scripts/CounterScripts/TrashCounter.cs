using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : ClearCounter
{
    protected override void OnPlayerHasItemCounterHasNoItem()
    {
        Debug.Log("Ich werde zerstört");
        Transform item = ItemManager.Instance.TransferKitchenObjectFromPlayerToCounter();
        Destroy(item.gameObject);
    }
}
