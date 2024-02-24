using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    [SerializeField] private ScriptableEvent OnDroppedIntoTrash;

    protected override void OnCounterReceivesItem()
    {
        OnDroppedIntoTrash.RaiseEvent();
        Transform item = ItemManager.Instance.GetItemFromPlayer();
        Destroy(item.gameObject);
    }
}
