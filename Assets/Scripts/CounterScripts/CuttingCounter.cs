using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    private float timeToCut = 5f;
    private float remainingCuttingTime;

    private void Update()
    {
        CheckCuttableObject();

    }

    private void CheckCuttableObject()
    {
        if( ingredient != null)
        {
            if (ingredient.IsCuttable)
            {
                if ( remainingCuttingTime > 0f ) 
                {
                    remainingCuttingTime -= Time.deltaTime;
                    if ( remainingCuttingTime < 0f )
                    {
                    }
                }
            }
        }
    }
}
