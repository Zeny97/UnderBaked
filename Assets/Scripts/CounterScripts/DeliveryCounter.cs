using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : CounterObject
{
    public override void InteractWithCounter()
    {
        Transform item = ItemManager.Instance.GetItemFromPlayer();
        Destroy(item.gameObject);
    }
}
