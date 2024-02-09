using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;
    [SerializeField] private List<ScriptableRecipe> Recipes;

    private List<ScriptableRecipe> waitingRecipeList;
    private int waitingRecipeMax = 4;
    private float recipeSpawnTimerMax = 4f;
    private float recipeSpawnTimer;

    private void Awake()
    {
        waitingRecipeList = new List<ScriptableRecipe>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        recipeSpawnTimer -= Time.deltaTime;
        if (recipeSpawnTimer <= 0)
        {
            recipeSpawnTimer = recipeSpawnTimerMax;
            if (waitingRecipeList.Count < waitingRecipeMax)
            {
                ScriptableRecipe waitingRecipe = Recipes[Random.Range(0, Recipes.Count)];
                Debug.Log(waitingRecipe.RecipeName);
                waitingRecipeList.Add(waitingRecipe);
            }
        }
    }

    public void DeliverRecipe(Plate deliveredPlate)
    {
        for (int i = 0; i < waitingRecipeList.Count; i++)
        {
            bool plateIngredientsMatchesRecipe = true;
            ScriptableRecipe recipe = waitingRecipeList[i];
            if (recipe.Ingredients.Count != deliveredPlate.itemsOnPlate.Length) continue;

            bool ingredientFound = false;
            foreach (Item.E_ItemIdentifier recipeIngredient in recipe.Ingredients)
            {
                foreach (Item plateIngredient in deliveredPlate.itemsOnPlate)
                {
                    if (plateIngredient.itemType == recipeIngredient)
                    {
                        ingredientFound = true;
                        break;
                    }
                }

                if (!ingredientFound)
                {
                    Debug.Log("Ingredient has not been found");
                    plateIngredientsMatchesRecipe = false;
                }
            }

            if (plateIngredientsMatchesRecipe)
            {
                Debug.Log("Player delivered a correct recipe");
                waitingRecipeList.RemoveAt(i);
                return;
            }


        }

        Debug.Log("Player did not deliver a correct recipe");
    }
}
