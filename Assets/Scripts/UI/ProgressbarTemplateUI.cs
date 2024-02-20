using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarTemplateUI : MonoBehaviour
{
    [SerializeField] private Image progressBarSprite;

    public void UpdateProgressBar(float currentCuttingTime, float totalCutTime)
    {
        progressBarSprite.fillAmount = currentCuttingTime / totalCutTime;
        // transform.LookAt(Camera.main.transform.position);
    }
}
