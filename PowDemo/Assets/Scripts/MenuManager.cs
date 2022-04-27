using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokeParticle;
    [Header("Game Stuff")]
    [SerializeField] private GameObject gameUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Image fadeImage;

    [Header("Menu")]
    [SerializeField] private GameObject optionsMenuHolder;
    [SerializeField] private Toggle[] resToggles;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private int[] screenWidths;
    int activeScreenResolutionIndex;

    private void Start()
    {   // OBSOLETE Event System Action
        //Inventory.instance.onGameOver += gameOver;

        smokeParticle.Play();
        activeScreenResolutionIndex = PlayerPrefs.GetInt("screen resolution index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        for (int i = 0; i < resToggles.Length; i++)
        {
            resToggles[i].isOn = i == activeScreenResolutionIndex;
        }
        fullscreenToggle.isOn = isFullscreen;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void startNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameUI.SetActive(false);
        StartCoroutine(fade(Color.clear, new Color(0, 0, 0, .95f), 2));
        gameOverUI.SetActive(true);
    }

    public void setScreenResolution(int i)
    {
        if (resToggles[i].isOn)
        {
            activeScreenResolutionIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen resolution index", activeScreenResolutionIndex);
            PlayerPrefs.Save();
        }
    }
    public void setFullscreen(bool isFullscreen)
    {
        for (int i = 0; i < resToggles.Length; i++)
        {
            resToggles[i].interactable = !isFullscreen;
        }
        if (isFullscreen)
        {
            Resolution[] resolutions = Screen.resolutions;
            Resolution maxResolution = resolutions[resolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            setScreenResolution(activeScreenResolutionIndex);
        }
        PlayerPrefs.SetInt("fullscreen", (isFullscreen) ? 1 : 0);
        PlayerPrefs.Save();
    }

    IEnumerator fade(Color from, Color to, float time)
    {
        float speed = 1 / time;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            fadeImage.color = Color.Lerp(from, to, percent);
            yield return null;
        }
    }
}
