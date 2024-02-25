using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene,
    }

    private static Scene targetScene;

    public static void Load(Scene _targetSceneName)
    {
        targetScene = _targetSceneName;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

        
    }

    internal static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
