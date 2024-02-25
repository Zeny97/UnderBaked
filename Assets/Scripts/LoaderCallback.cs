using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdateCalled = true;
    // First Update indicates that targetscene has loaded
    private void Update()
    {
        if (isFirstUpdateCalled)
        {
            isFirstUpdateCalled = false;
            Loader.LoaderCallback();
        } 
    }
}
