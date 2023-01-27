using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSlider : MonoBehaviour
{
    public PopUpVolume popUpVolume;
    [SerializeField] AudioSettings audioSettings;

    public bool popUpEnabled = false;

    void OnEnable()
    {
        popUpEnabled = true;
        popUpVolume.popUpMaxSlider.onValueChanged.AddListener(popUpVolume.SetMasterVolume);
        popUpVolume.popUpMaxSlider.value = audioSettings.masterSlider.value;
    }

    void Update()
    {
        
    }
}
