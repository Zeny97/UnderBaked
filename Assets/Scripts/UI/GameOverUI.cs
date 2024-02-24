using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);
    }
}
