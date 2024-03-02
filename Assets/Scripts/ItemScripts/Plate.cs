using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Plate : Item
{
    public List<Item> Ingredients;
    [SerializeField] private int maxPlateItems;
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
        // Icons look at Z Direction of camera
        container.transform.forward = Camera.main.transform.forward;
    }

    public bool PutItemOnPlate(Item item)
    {
        // only combinable Items can be put on plate. Exception for MeatPatty, because it can get further processed, so its not a "combinable item"
        if (item is CombinableItem || item.itemType == E_ItemIdentifier.MeatPattyCooked)
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
        return false;
    }



    public void UpdateVisual()
    {
        // Updates Visual above the plate about which ingredients are already on it
        // remove all current displayed ingredients
        for (int i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }

        // display all ingredients + the added ingredient
        for(int i = 0;  i < curPlateItemAmount; i++)
        {
            newIcon = Instantiate(singleIcon, container.transform);
            newIcon.GetComponent<Image>().sprite = Ingredients[i].itemSprite;
        }
    }
}
