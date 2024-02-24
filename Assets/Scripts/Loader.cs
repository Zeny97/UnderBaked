using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject m_OptionsMenu;
    [SerializeField] private GameObject m_GameOver;


    public enum Scene
    {
        GameScene,
        MainMenu
    }

    public static void SwitchScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public static void LoadOptionsMenu()
    {

    }

    public static void LoadGameOverMenu()
    {

    }
}
