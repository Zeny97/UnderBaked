using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttableItem cuttableItem;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float totalCutTime = 5f;
    private float currentCuttingTime = 0f;

    private void Start()
    {
        progressBar.transform.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckCuttingProcess();
        IsCutting();
    }

    private void CheckCuttingProcess()
    {
        if(cuttableItem != null)
        {

            progressBar.transform.gameObject.SetActive(true);
            progressBar.UpdateProgressBar(currentCuttingTime, totalCutTime);
            if ( currentCuttingTime < totalCutTime ) 
            {
                currentCuttingTime += Time.deltaTime;
                if ( currentCuttingTime >= totalCutTime )
                {
                    OnFinishedCutting();
                    progressBar.transform.gameObject.SetActive(false);
                    currentCuttingTime = 0;
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

    protected override void OnCounterReceivesItem()
    {
        base.OnCounterReceivesItem();
        cuttableItem = ingredient.gameObject.GetComponent<CuttableItem>();
    }

    protected override void OnPlayerReceivesItem()
    {
        if (IsCutting())
        {
            return;
        }
        base.OnPlayerReceivesItem();
    }

    private bool IsCutting()
    {
        if(currentCuttingTime > 0 && currentCuttingTime < totalCutTime)
        {
            return true;
        }
        return false;
    }
}
