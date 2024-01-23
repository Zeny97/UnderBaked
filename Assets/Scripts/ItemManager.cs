using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] private Player player;
    [SerializeField] private GameObject Itemholder;


    private void Awake()
    {
        if( Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
    }

    public bool HasItem() 
    {
        if(Itemholder.transform.childCount != 0 )
            return true;
        return false;
        
    }

    public void SpawnItem(GameObject ingredient)
    {
        GameObject myCheese = Instantiate(ingredient, Itemholder.transform);
    }
}
