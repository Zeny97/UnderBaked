using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBarSprite;

    public void UpdateProgressBar(float currentCuttingTime, float totalCutTime)
    {
        progressBarSprite.fillAmount = currentCuttingTime / totalCutTime;
    }
}
