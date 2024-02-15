using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;
    [SerializeField] private ScriptableEvent OnRecipeSpawned;
    [SerializeField] private ScriptableEvent OnRecipeCompleted;
    [SerializeField] private List<ScriptableRecipe> Recipes;

    private List<ScriptableRecipe> waitingRecipeList;
    private int waitingRecipeMax = 4;
    private float recipeSpawnTimerMax = 4f;
    private float recipeSpawnTimer;

    private void Awake()
    {
        waitingRecipeList = new List<ScriptableRecipe>();
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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
                OnRecipeSpawned.RaiseEvent(waitingRecipe);
            }
        }
    }

    public void DeliverRecipe(Plate deliveredPlate)
    {
        // Go through every waiting recipe
        for (int i = 0; i < waitingRecipeList.Count; i++)
        {
            // bool isn't changed if all ingredients on Plate match the order
            bool plateIngredientsMatchesRecipe = true;
            ScriptableRecipe recipe = waitingRecipeList[i];

            // Check if number of Items Match with number of items on waitingrecipe
            // if (recipe.Ingredients.Count != deliveredPlate.itemsOnPlate.Length) continue;

            bool ingredientFound = false;

            // Check each ingredient on the current waiting recipe
            foreach (Item.E_ItemIdentifier recipeIngredient in recipe.Ingredients)
            {
                // Check each ingredient on the delivered Plate
                int counter = 0;

                foreach (Item plateIngredient in deliveredPlate.itemsOnPlate)
                {
                    if (deliveredPlate.itemsOnPlate[counter] == null) break; 
                    counter++;
                    // Is the item on the plate somewhere in the recipe
                    if (plateIngredient.itemType == recipeIngredient)
                    {
                        ingredientFound = true;
                        break;
                    }
                }

                // ingredient couldn't be found
                if (!ingredientFound)
                {
                    Debug.Log("Ingredient has not been found");
                    plateIngredientsMatchesRecipe = false;
                    break;
                }
            }

            // Plate content and recipe content match
            if (plateIngredientsMatchesRecipe)
            {

                OnRecipeCompleted.RaiseEvent(waitingRecipeList[i].RecipeScoreValue);
                waitingRecipeList.RemoveAt(i);
                return;
            }


        }

        // Plate content didn't match with any waiting recipe
        Debug.Log("Player did not deliver a correct recipe");
    }

    public List<ScriptableRecipe> GetWaitingRecipeList()
    {
        return waitingRecipeList;
    }
}
