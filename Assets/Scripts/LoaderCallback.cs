using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdateCalled = true;
    // First Update indicates that targetscene has loaded. Loading screen is going to switch to target scene
    private void Update()
    {
        if (isFirstUpdateCalled)
        {
            isFirstUpdateCalled = false;
            Loader.LoaderCallback();
        } 
    }
}
