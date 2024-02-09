using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : CounterObject
{
    [SerializeField] private Plate plate;
    public override void InteractWithCounter()
    {
        if (ItemManager.Instance.PlayerHasKitchenObject())
        {
            if(ItemManager.Instance.GetKitchenObject().itemType == Item.E_ItemIdentifier.Plate)
            {
                plate = ItemManager.Instance.GetPlate();
                RecipeManager.Instance.DeliverRecipe(plate);
                Destroy(plate);
            }
        }
    }
}
