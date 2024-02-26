using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TextMeshProUGUI highscoreText;

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

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highscoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
}
