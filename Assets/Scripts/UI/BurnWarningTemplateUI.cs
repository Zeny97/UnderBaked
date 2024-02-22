using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurnWarningTemplateUI : MonoBehaviour
{
    [SerializeField] private Image warningSprite;
    private void Awake()
    {
        warningSprite.transform.gameObject.SetActive(false);
    }

    public void UpdateWarningStatus(Item _item)
    {
        if (_item.itemType == Item.E_ItemIdentifier.MeatPattyCooked)
        {
        warningSprite.gameObject.SetActive(true);
        }
        else warningSprite.gameObject.SetActive(false);
    }
}
