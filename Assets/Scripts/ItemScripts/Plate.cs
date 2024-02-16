using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Plate : Item
{
    [SerializeField] private int maxPlateItems;
    public List<Item> Ingredients;
    [SerializeField] private int curPlateItemAmount;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private Transform container;
    [SerializeField] GameObject singleIcon;
    private GameObject newIcon;

    private void Awake()
    {
        Ingredients = new List<Item>();
        curPlateItemAmount = 0;
    }

    private void Update()
    {
        IconsLookAtCamera();
    }

    private void IconsLookAtCamera()
    {
        container.transform.forward = Camera.main.transform.forward;
    }

    public bool PutItemOnPlate(Item item)
    {
        // When plate full
        if(curPlateItemAmount >= maxPlateItems)
        {
            return false;
        }

        // Add item to plate
        Ingredients.Add(item);
        curPlateItemAmount++;

        item.transform.SetParent(itemHolder);
        item.transform.position = itemHolder.transform.position;
        item.transform.rotation = itemHolder.transform.rotation;
        UpdateVisual();
        return true;
    }



    public void UpdateVisual()
    {
        for (int i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }


        for(int i = 0;  i < curPlateItemAmount; i++)
        {
            newIcon = Instantiate(singleIcon, container.transform);
            newIcon.GetComponent<Image>().sprite = Ingredients[i].itemSprite;
        }
    }


}
