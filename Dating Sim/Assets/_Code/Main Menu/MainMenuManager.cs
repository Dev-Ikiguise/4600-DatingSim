using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    int nextSceneIndex;
    FadeManager fadeManager;

    void Awake()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        fadeManager = GetComponent<FadeManager>();
    }

    public void OpenSaveSelection()
    {
        //Go to saves
    }

    public void PlayIntroScene()
    {
        //Go into a cinematic
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OpenCredits()
    {
        //Go to credits
    }

    public void OpenAllSettings()
    {
        //Go to all settings
    }

    public void OpenVolumeSettings()
    {
        //Go to volume settings
    }

    public void QuitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
