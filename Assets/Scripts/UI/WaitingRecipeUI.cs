using TMPro;
using UnityEngine;

public class WaitingRecipeUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        UpdateVisual();
    }

    public void UpdateVisual() 
    {
        // Destroy each child except recipeTemplate

        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        // Cycle through all waiting recipes
        foreach(ScriptableRecipe recipe in RecipeManager.instance.GetWaitingRecipeList())
        {
            //spawn recipeTemplate at Transform position of the container and make it visible
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<RecipeTemplateUI>().SetScriptableRecipe(recipe);
        }
    }
}
