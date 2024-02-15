using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryCounter : CounterObject
{
    [SerializeField] private Plate plate;
    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.PlayerHasKitchenObject())
        {
            if (ItemManager.Instance.GetKitchenObject().itemType == Item.E_ItemIdentifier.Plate)
            {
                plate = ItemManager.Instance.GetPlate();
                if (plate.itemsOnPlate.Length > 0)
                {
                    RecipeManager.instance.DeliverRecipe(plate);
                    Destroy(plate.gameObject);
                    return;
                }
            }
            Debug.Log("There are no Items on the Plate");

        }
    }
}
