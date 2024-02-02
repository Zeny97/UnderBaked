using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private float totalCookingTime = 5f;
    private float remainingCookingTime;
    private CookableItem cookableItem;

    private void Awake()
    {
        remainingCookingTime = 0f;
    }
    private void Update()
    {
        CheckCookingProcess();
        IsCooking();
    }

    private void IsCooking()
    {
        if (remainingCookingTime > 0 && remainingCookingTime < totalCookingTime)
        {

        }
    }

    private void CheckCookingProcess()
    {
        if (cookableItem != null)
        {
            if (remainingCookingTime > 0f)
            {
                remainingCookingTime -= Time.deltaTime;
                if (remainingCookingTime <= 0f)
                {
                    OnFinishedCooking();
                    remainingCookingTime = totalCookingTime;
                }
            }
        }
    }

    private void OnFinishedCooking()
    {
        GameObject newItem = Instantiate(cookableItem.CookedItem().gameObject);
        newItem.transform.SetParent(ingredient.transform.parent);
        newItem.transform.position = ingredient.transform.position;
        newItem.transform.rotation = ingredient.transform.rotation;
        Destroy(ingredient.gameObject);
        cookableItem = null;
        ingredient = newItem.GetComponent<Item>();
    }

    protected override void OnCounterReceivesItem()
    {
        base.OnCounterReceivesItem();
        cookableItem = ingredient.gameObject.GetComponent<CookableItem>();
    }
}
