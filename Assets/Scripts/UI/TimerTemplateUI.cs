using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerTemplateUI : MonoBehaviour
{
    [SerializeField] private ScriptableEvent OnTimerRunsOut;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Transform timerTransform;
    private float timer;
    private void Awake()
    {
        timer = 300;
        timerText.text = timer.ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        timerText.text = time.ToString(@"mm\:ss");

    }
    public void UpdateTimer()
    {
        timer += RecipeManager.instance.GetRecipeTimeIncrease();
    }
}
