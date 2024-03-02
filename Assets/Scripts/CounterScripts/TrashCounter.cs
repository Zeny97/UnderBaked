using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    [SerializeField] private ScriptableEvent OnDroppedIntoTrash;

    protected override void OnCounterReceivesItem()
    {
        // Play audio clip specific to putting an item into the trash and destroy the Gameobject
        OnDroppedIntoTrash.RaiseEvent();
        Transform item = ItemManager.Instance.GetItemFromPlayer();
        Destroy(item.gameObject);
    }
}
