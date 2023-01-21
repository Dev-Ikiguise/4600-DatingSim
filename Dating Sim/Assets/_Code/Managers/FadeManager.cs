using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public bool useFadeTransition = true;
    public AnimationCurve fadeCurve;

    private CanvasGroup _fadeCanvasGroup;

    private void Start()
    {
        // Create a new canvas group to use for the fade effect
        _fadeCanvasGroup = new GameObject("Fade Canvas Group").AddComponent<CanvasGroup>();
        _fadeCanvasGroup.gameObject.AddComponent<Canvas>();

        // Set the canvas group's alpha to 1 to start with a black screen
        _fadeCanvasGroup.alpha = 1;
    }

    public void LoadScene(string sceneName)
    {
        if (useFadeTransition)
        {
            StartCoroutine(FadeAndLoadScene(sceneName));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            _fadeCanvasGroup.alpha = fadeCurve.Evaluate(time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);

        // Fade in
        time = 0;
    }

    }
