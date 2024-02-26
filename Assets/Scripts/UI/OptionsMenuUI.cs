using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        Hide();
        
    }

    private void OnEnable()
    {
        audioMixer.GetFloat("Volume", out float currentVolume);
        volumeSlider.value = Mathf.Pow(10,(currentVolume/20));
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
