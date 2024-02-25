using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayingTimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public float timer { get; private set; }

    private void Start()
    {
        Hide();
        timer = GameManager.Instance.GetGamePlayingTimer();
        timerText.text = timer.ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(GameManager.Instance.GetGamePlayingTimer()).ToString();
    }
    public void IncreaseGameTimerByRecipeValue()
    {
        float timeIncrement = RecipeManager.instance.GetRecipeTimeIncrease();
        timer += timeIncrement;
        GameManager.Instance.SetGamePlayingTimer(timer);
    }

    public void ShowGamePlayingTimerUI()
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
