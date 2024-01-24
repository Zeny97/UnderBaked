using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    

    private void Update()
    {
        CheckCuttableObject();

    }

    private void CheckCuttableObject()
    {
        if (ingredient.IsCuttable)
        {

        }
    }
}
