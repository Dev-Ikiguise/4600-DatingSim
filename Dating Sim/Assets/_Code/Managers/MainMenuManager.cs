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

    // Update is called once per frame
    void Update()
    {
        
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
