using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        Hide();
    }
    private void Update()
    {
        scoreText.text = RecipeManager.instance.GetScore().ToString();
    }

    public void ShowScoreUI()
    {
        if (GameManager.Instance.isGameInPlayingState())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
