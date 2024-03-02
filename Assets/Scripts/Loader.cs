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
        // targetscene is set. Loading screen scene is loaded
        targetScene = _targetSceneName;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());  
    }

    internal static void LoaderCallback()
    {
        // once first Update of targetscene ran, load the target scene
        SceneManager.LoadScene(targetScene.ToString());
    }
}
