using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public float score;
    public float timer;

    private void Awake()
    {
        if (instance != null && instance!= this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void UpdateScore(float )
    {
        
    }

    public void UpdateWaitingRecipes() 
    {
        
    }

    public void UpdateTimer()
    {
       
    }
}
