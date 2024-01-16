using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public enum E_CounterType
{
    clearCounter = 1,
    cuttingCounter,
    containerCounter,
    stoveCounter,
    plateCounter,
    deliveryCounter,
}
public abstract class Counters : MonoBehaviour , IInteractable
{
    

    public E_CounterType Interact()
    {
        return E_CounterType.clearCounter;
    }
}
