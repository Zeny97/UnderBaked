using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableRecipe")]
public class ScriptableRecipe : ScriptableObject
{
    public List<Item.E_ItemIdentifier> Ingredients;
    public string RecipeName;
}

