using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : MonoBehaviour, ICounterInteraction
{
    public void Interact()
    {
        Debug.Log("This is a:" + this.gameObject.name);
    }
}
