using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    public static readonly string MasterPref = "MasterPref";
    public static readonly string MusicPref = "MusicPref";
    public static readonly string SoundEffectsPref = "SoundEffectsPref";
    public static readonly string DialoguePref = "DialoguePref";

    [SerializeField] AudioMixer mixer;

    public const string MIXER_MASTER = "MasterVolume";
    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";
    public const string MIXER_DIALOGUE = "DialogueVolume";

    private int firstPlayInt;
    public Slider masterSlider, musicSlider, soundEffectsSlider, dialogueSlider;
    private float masterFloat, musicFloat, soundEffectsFloat, dialogueFloat;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundEffectsSlider.onValueChanged.AddListener(SetSFXVolume);
        dialogueSlider.onValueChanged.AddListener(SetDialogueVolume);
    }

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            masterFloat = 1f;
            musicFloat = 1f;
            soundEffectsFloat = 1f;
            dialogueFloat = 1f;

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

    private void OnDisable()
    {
        SaveSoundSettings();
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
        PlayerPrefs.SetFloat(DialoguePref, dialogueSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void SetDialogueVolume(float value)
    {
        mixer.SetFloat(MIXER_DIALOGUE, Mathf.Log10(value) * 20);
    }
}
