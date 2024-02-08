using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager Instance;
    public Dictionary<string, Recipe> Recipes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeRecipes();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Recipe randomRecipe = RecipeManager.Instance.SelectRandomRecipe();
    }

    private void InitializeRecipes()
    {
        Recipes = new Dictionary<string, Recipe>();

        AddRecipe("Burger", new List<string> {"Bread", "Tomato Slices", "Cabbage Slices", "Cheese Slices", "Cooked Meat"});
        AddRecipe("Salad", new List<string> { "Cabbage Slices", "Cabbage Slices", "Tomato Slices" });
    }

    private void AddRecipe(string name, List<string> ingredients)
    {
        Recipe recipe = new Recipe(name, ingredients);
        Recipes.Add(name, recipe);
    }

    public Recipe SelectRandomRecipe()
    {
        List<string> keys = new List<string>(Recipe.Keys);
        string randomRecipe = keys[Random.Range(0, keys.Count)];
        return Recipes[randomRecipe];
    }

}

public class Recipe
{
    public string Name;
    public List<string> Ingrediens;

    public Recipe( string name, List<string> ingrediens)
    {
        Name = name;
        Ingrediens = ingrediens;
    }

    public static IEnumerable<string> Keys { get; internal set; }
}
