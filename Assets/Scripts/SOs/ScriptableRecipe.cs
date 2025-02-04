using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ScriptableRecipe")]
public class ScriptableRecipe : ScriptableObject
{
    public List<Item> Ingredients;
    public string RecipeName;
    public float RecipeScoreValue;
    public float TimeIncrement;
}


