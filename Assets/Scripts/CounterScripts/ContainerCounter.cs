using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : CounterObject
{
    [SerializeField] private GameObject ingredient;
    public override void InteractWithCounter()
    {
        if (!ItemManager.Instance.HasItem())
        {
            ItemManager.Instance.SpawnItem(ingredient);
        }
    }
}
