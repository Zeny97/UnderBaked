using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;
    [SerializeField] private ScriptableEvent OnRecipeSpawned;
    [SerializeField] private ScriptableEvent OnRecipeCompleted;
    [SerializeField] private List<ScriptableRecipe> Recipes;
    private float deliveredRecipeScoreValue;
    private List<ScriptableRecipe> waitingRecipeList;
    private int waitingRecipeMax = 4;
    private float recipeSpawnTimerMax = 4f;
    private float recipeSpawnTimer;
    private float deliveredRecipeTimeValue;

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

    public void DeliverRecipe(Plate _deliveredPlate)
    {
        // Cycle through every waiting recipe
        Debug.Log("Ich bin in der DeliverRecipe Methode");
        for (int i = 0; i < waitingRecipeList.Count; i++)
        {
            Debug.Log("Ich gehe gerade durch jedes Rezept");
            ScriptableRecipe recipe = waitingRecipeList[i];
            // Has the same number of ingredients
            if (_deliveredPlate.Ingredients.Count == recipe.Ingredients.Count)
            {
                Debug.Log("Der Teller und das Rezept haben die Selbe Menge an Zutaten");
                bool isPlateMatchingRecipe = CompareItemContents(_deliveredPlate, recipe);
                
                if (isPlateMatchingRecipe)
                {
                    deliveredRecipeScoreValue = recipe.RecipeScoreValue;
                    deliveredRecipeTimeValue = recipe.TimeIncrement;
                    waitingRecipeList.RemoveAt(i);
                    OnRecipeCompleted.RaiseEvent();
                    Debug.Log("Recipe succesfully delivered");
                    break;
                }
                else
                {
                    // Player delivered wrong recipe
                    Debug.Log("Player did not deliver a correct recipe");
                }
            }
        } 
    }

    private bool CompareItemContents(Plate _deliveredPlate, ScriptableRecipe _recipe)
    {
        // Cycle through each ingredient in the recipe
        foreach (Item recipeIngredient in _recipe.Ingredients)
        {
            bool isIngredientFound = false;
            // Cycle through each ingredient in the Plate
            foreach (Item plateIngredient in _deliveredPlate.Ingredients)
            {
                // ingredient matches
                Debug.Log(recipeIngredient);
                if (plateIngredient.itemType == recipeIngredient.itemType)
                {
                    isIngredientFound = true;
                    break;
                }
            }

            // ingredient doesn't match
            if (!isIngredientFound)
            {
                return false;
            }
        }

        // every ingredient matched
        return true;
    }
    public List<ScriptableRecipe> GetWaitingRecipeList()
    {
        return waitingRecipeList;
    }

    public float GetRecipeScore()
    {
        return deliveredRecipeScoreValue;
    }

    public float GetRecipeTimeIncrease()
    {
        return deliveredRecipeTimeValue;
    }
}
