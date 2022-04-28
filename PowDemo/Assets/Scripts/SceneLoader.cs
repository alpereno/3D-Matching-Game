using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Invoke("createUIScene", .1f);
    }

    void createUIScene()
    {
        if (!SceneManager.GetSceneByBuildIndex(1).IsValid())
        {
            SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Additive);
        }
    }
}
