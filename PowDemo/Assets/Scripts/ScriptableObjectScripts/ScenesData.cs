using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/SceneDatabase")]
public class ScenesData : ScriptableObject
{
    public GameScene gameScene;
    public GameScene menuScene;

    public void startNewGame()
    {
        SceneManager.LoadSceneAsync(gameScene.sceneName);
        SceneManager.LoadSceneAsync(menuScene.sceneName, LoadSceneMode.Additive);
    }

    public void quit()
    {
        Application.Quit();
    }
}
