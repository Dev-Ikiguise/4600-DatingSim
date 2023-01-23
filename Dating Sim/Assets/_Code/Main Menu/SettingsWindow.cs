using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    public float leanAnimationOpenSeconds = 0.8f;
    public float leanAnimationCloseSeconds = 1f;

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, leanAnimationOpenSeconds);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, leanAnimationCloseSeconds).setEaseInBack();
    }
}
