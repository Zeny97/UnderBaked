using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] protected Item ItemToSpawn;
    [SerializeField] private float TimeBetweenSpawns;
    private float currentTime;
    protected virtual void OnTimerElapsed(Item ingredient)
    {
        Item spawnedIngredient= Instantiate(ingredient, CounterItemHolder.transform);
        Ingredient = spawnedIngredient.GetComponent<Item>();
    }
    private void Start()
    {
        currentTime = TimeBetweenSpawns;
    }
    private void Update()
    {
        if ( currentTime >= 0 )
        {
            currentTime -= Time.deltaTime;
            if ( currentTime <= 0 )
            {
                currentTime = TimeBetweenSpawns;
                if (Ingredient == null )
                {
                    OnTimerElapsed(ItemToSpawn);
                }
            }
        }
    }
}
