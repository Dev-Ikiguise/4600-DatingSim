using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioMixer mixer;

    public Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.loop = s.loop;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        LoadVolume();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //Volume Saved In AudioSettings.cs
    void LoadVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat(AudioSettings.MasterPref, 1f);
        float musicVolume = PlayerPrefs.GetFloat(AudioSettings.MusicPref, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(AudioSettings.SoundEffectsPref, 1f);
        float dialogueVolume = PlayerPrefs.GetFloat(AudioSettings.DialoguePref, 1f);

        mixer.SetFloat(AudioSettings.MIXER_MASTER, Mathf.Log10(masterVolume) * 20);
        mixer.SetFloat(AudioSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(AudioSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(AudioSettings.MIXER_DIALOGUE, Mathf.Log10(dialogueVolume) * 20);
    }
}
