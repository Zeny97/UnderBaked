using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] protected Item ItemToSpawn;
    [SerializeField] private float TimeBetweenSpawns;
    private float currentTime;

    private void Start()
    {
        currentTime = TimeBetweenSpawns;
    }
    private void Update()
    {
        // Countdown loop, which spawns Item on Top of Counter, if there is no item on top already
        if ( currentTime >= 0 )
        {
            currentTime -= Time.deltaTime;
            if ( currentTime <= 0 )
            {
                currentTime = TimeBetweenSpawns;
                if (Item == null )
                {
                    OnTimerElapsed(ItemToSpawn);
                }
            }
        }
    }

    protected virtual void OnTimerElapsed(Item ingredient)
    {
        Item spawnedIngredient = Instantiate(ingredient, CounterItemHolder.transform);
        Item = spawnedIngredient.GetComponent<Item>();
    }
}
