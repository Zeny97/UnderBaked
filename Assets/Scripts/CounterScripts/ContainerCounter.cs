using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] protected GameObject itemToSpawn;
    [SerializeField] private float timeBetweenSpawns;
    private float currentTime;
    protected virtual void OnTimerElapsed(GameObject _ingredient)
    {
        GameObject spawnedIngredient= Instantiate(_ingredient, counterItemHolder.transform);
        ingredient = spawnedIngredient.GetComponent<Item>();
    }
    private void Start()
    {
        currentTime = timeBetweenSpawns;
    }
    private void Update()
    {
        if ( currentTime >= 0 )
        {
            currentTime -= Time.deltaTime;
            if ( currentTime <= 0 )
            {
                currentTime = timeBetweenSpawns;
                if (ingredient == null )
                {
                    OnTimerElapsed(itemToSpawn);
                }
            }
        }
    }
}
