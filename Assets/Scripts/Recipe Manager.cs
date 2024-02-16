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
            // doesn't change unless ingredient is missing
            bool isPlateMatchingRecipe = true;
            bool isIngredientFound = false;
            ScriptableRecipe recipe = waitingRecipeList[i];
            // Check each ingredient on the current waiting recipe
            foreach (Item recipeIngredient in recipe.Ingredients)
            {
                // Check each ingredient on the delivered Plate
                int counter = 0;
                foreach (Item plateIngredient in deliveredPlate.itemsOnPlate)
                {
                    if (deliveredPlate.itemsOnPlate[counter] == null) break; 
                    counter++;
                    // Is the item on the plate somewhere in the recipe
                    if (plateIngredient == recipeIngredient)
                    {
                        isIngredientFound = true;
                        break;
                    }
                }
                // ingredient couldn't be found
                if (!isIngredientFound)
                {
                    Debug.Log("Ingredient has not been found");
                    isPlateMatchingRecipe = false;
                    break;
                }
            }
            // Player delivered correct recipe
            if (isPlateMatchingRecipe)
            {
                waitingRecipeList.RemoveAt(i);
                OnRecipeCompleted.RaiseEvent();
                return;
            }
        }
        // Player didn't deliver correct recipe
        Debug.Log("Player did not deliver a correct recipe");
    }

    public List<ScriptableRecipe> GetWaitingRecipeList()
    {
        return waitingRecipeList;
    }
}
