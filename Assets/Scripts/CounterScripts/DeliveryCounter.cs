using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryCounter : CounterObject
{
    [SerializeField] private Plate plate;
    public override void InteractWithCounter()
    {
        // Checks Player Item
        if (ItemManager.Instance.PlayerHasKitchenObject())
        {
            // Check if Item is a Plate
            if (ItemManager.Instance.GetKitchenObject().itemType == Item.E_ItemIdentifier.Plate)
            {
                // Plate is going to be checked for its ingredients and removed from the player
                plate = ItemManager.Instance.GetPlate();
                if (plate.Ingredients.Count > 0)
                {
                    RecipeManager.instance.DeliverRecipe(plate);
                    Destroy(plate.gameObject);
                    return;
                }
            }
        }
    }
}
