using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    [SerializeField] private float timeToCut = 5f;
    private float remainingCuttingTime;
    private CuttableItem cuttableItem;

    private void Awake()
    {
        remainingCuttingTime = timeToCut;
    }
    private void Update()
    {
        CheckCuttingProcess();
    }

    private void CheckCuttingProcess()
    {
        if( cuttableItem != null)
        {
            if ( remainingCuttingTime > 0f ) 
            {
                remainingCuttingTime -= Time.deltaTime;
                if ( remainingCuttingTime <= 0f )
                {
                    OnFinishedCutting();
                    remainingCuttingTime = timeToCut;
                }
            }
        }
    }

    private void OnFinishedCutting()
    {
        GameObject newItem = Instantiate(cuttableItem.CuttedItem().gameObject);
        newItem.transform.SetParent(ingredient.transform.parent);
        newItem.transform.position = ingredient.transform.position;
        newItem.transform.rotation = ingredient.transform.rotation;
        Destroy(ingredient.gameObject);
        cuttableItem = null;
        ingredient = newItem.GetComponent<Item>();
    }

    protected override void OnPlayerHasItemCounterHasNoItem()
    {
        base.OnPlayerHasItemCounterHasNoItem();
        cuttableItem = ingredient.gameObject.GetComponent<CuttableItem>();
    }
}
