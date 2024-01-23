using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : CounterObject
{
    [SerializeField] private Player _player;
    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.HasItem())
        {

        }

    }
}
