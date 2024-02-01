using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    protected override void OnCounterReceivesItem()
    {
        Transform item = ItemManager.Instance.TransferKitchenObjectFromPlayerToCounter();
        Destroy(item.gameObject);
    }
}
