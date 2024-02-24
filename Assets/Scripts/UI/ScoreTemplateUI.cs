using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTemplateUI : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Transform scoreTransform;
    public float score { get; private set; }
    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        score += RecipeManager.instance.GetRecipeScore();
        scoreText.text = score.ToString();
    }
}
