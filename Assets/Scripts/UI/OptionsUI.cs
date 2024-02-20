using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Transform optionsUI;
    private void Awake()
    {
        optionsUI.gameObject.SetActive(false);
    }
}
