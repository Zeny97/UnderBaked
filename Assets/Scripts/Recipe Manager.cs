using System.Collections.Generic;
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
        // Countdown spawntimer
        recipeSpawnTimer -= Time.deltaTime;
        if (recipeSpawnTimer <= 0)
        {
            recipeSpawnTimer = recipeSpawnTimerMax;
            if (waitingRecipeList.Count < waitingRecipeMax)
            {
                ScriptableRecipe waitingRecipe = Recipes[Random.Range(0, Recipes.Count)];
                waitingRecipeList.Add(waitingRecipe);

                OnRecipeSpawned.RaiseEvent();
            }
        }
    }

    public void DeliverRecipe(Plate deliveredPlate)
    {
        // Cycle through every waiting recipe
        for (int i = 0; i < waitingRecipeList.Count; i++)
        {
            ScriptableRecipe recipe = waitingRecipeList[i];
            // Has the same number of ingredients
            if (deliveredPlate.Ingredients.Count == waitingRecipeList.Count)
            {
                bool isPlateMatchingRecipe = CompareItemContents(deliveredPlate, recipe);
                
                if (isPlateMatchingRecipe)
                {
                    waitingRecipeList.RemoveAt(i);
                    OnRecipeCompleted.RaiseEvent();
                }
            }
        }
        // Player delivered wrong recipe
        Debug.Log("Player did not deliver a correct recipe");
    }

    private bool CompareItemContents(Plate deliveredPlate, ScriptableRecipe recipe)
    {
        // Cycle through each ingredient in the recipe
        foreach (Item recipeIngredient in recipe.Ingredients)
        {
            bool isIngredientFound = false;
            // Cycle through each ingredient in the Plate
            foreach (Item plateIngredient in deliveredPlate.Ingredients)
            {
                // ingredient matches
                if (plateIngredient == recipeIngredient)
                {
                    isIngredientFound = true;
                    break;
                }
            }

            if (!isIngredientFound)
            {
                return false;
            }
        }
        return true;
    }
    public List<ScriptableRecipe> GetWaitingRecipeList()
    {
        return waitingRecipeList;
    }
}
