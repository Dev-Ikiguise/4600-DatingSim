using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MasterPref = "MasterPref";
    private static readonly string MusicPref = "MasterPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private static readonly string DialoguePref = "dialoguePref";

    [SerializeField] AudioMixer mixer;

    private int firstPlayInt;
    public Slider masterSlider, musicSlider, soundEffectsSlider, dialogueSlider;
    private float masterFloat, musicFloat, soundEffectsFloat, dialogueFloat;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            masterFloat = 100f;
            musicFloat = 100f;
            soundEffectsFloat = 100f;
            dialogueFloat = 100f;

            masterSlider.value = masterFloat;
            musicSlider.value = musicFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            dialogueSlider.value = dialogueFloat;

            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(MusicPref, masterFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, masterFloat);
            PlayerPrefs.SetFloat(DialoguePref, masterFloat);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            masterFloat = PlayerPrefs.GetFloat(MasterPref);
            masterSlider.value = masterFloat;

            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;

            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;

            dialogueFloat = PlayerPrefs.GetFloat(DialoguePref);
            dialogueSlider.value = dialogueFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
        PlayerPrefs.SetFloat(MusicPref, masterSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, masterSlider.value);
        PlayerPrefs.SetFloat(DialoguePref, masterSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }
}
