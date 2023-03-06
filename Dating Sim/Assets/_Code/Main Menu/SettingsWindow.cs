 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    public float leanAnimationOpenSeconds = 0.4f;
    public float leanAnimationCloseSeconds = 0.6f;

    public bool isActive;
    [SerializeField] PopUpVolume popUpVolume;
    [SerializeField] AudioSettings audioSettings;

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void SetMusicVolume(float musicVolume)
    {
        Debug.Log(musicVolume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, leanAnimationOpenSeconds);
        isActive = true;
        audioSettings.masterSlider.value = popUpVolume.popUpMaxSlider.value;
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, leanAnimationCloseSeconds).setEaseInBack();
        isActive = false;
    }
}
