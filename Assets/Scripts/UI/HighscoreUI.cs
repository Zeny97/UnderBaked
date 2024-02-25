using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscore;

    private void Start()
    {
        Hide();
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    public void UpdateHighscore()
    {
        float score = RecipeManager.instance.GetScore();
        highscore.text =  PlayerPrefs.GetFloat("HighScore").ToString();
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highscore.text = score.ToString();
        }
    }

    public void ShowHighscoreUI()
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
