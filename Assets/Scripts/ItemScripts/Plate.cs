using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Plate : Item
{
    [SerializeField] private int maxPlateItems;
    public Item[] itemsOnPlate;
    [SerializeField] private int curPlateItemAmount;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private Transform iconHolder;
    [SerializeField] GameObject singleIcon;
    private GameObject newIcon;

    private void Awake()
    {
        itemsOnPlate = new Item[maxPlateItems];
        curPlateItemAmount = 0;
    }

    private void Update()
    {
        IconsLookAtCamera();
    }

    private void IconsLookAtCamera()
    {
        //iconHolder.transform.LookAt(Camera.main.transform.position, Camera.main.transform.forward);
        iconHolder.transform.forward = Camera.main.transform.forward;
    }

    public bool PutItemOnPlate(Item item)
    {
        // Wenn Teller voll
        if(curPlateItemAmount >= maxPlateItems)
        {
            return false;
        }

        // Füge Item dem Teller hinzu
        itemsOnPlate[curPlateItemAmount] = item;
        curPlateItemAmount++;

        item.transform.SetParent(itemHolder);
        item.transform.position = itemHolder.transform.position;
        item.transform.rotation = itemHolder.transform.rotation;
        UpdateVisual();
        return true;
    }



    public void UpdateVisual()
    {
        for (int i = 0; i < iconHolder.childCount; i++)
        {
            Destroy(iconHolder.GetChild(i).gameObject);
        }


        for(int i = 0;  i < curPlateItemAmount; i++)
        {
            newIcon = Instantiate(singleIcon, iconHolder.transform);
            newIcon.GetComponent<Image>().sprite = itemsOnPlate[i].itemSprite;
        }
    }


}
