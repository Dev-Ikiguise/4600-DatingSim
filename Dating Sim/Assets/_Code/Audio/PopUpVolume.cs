using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpVolume : MonoBehaviour
{
    public Slider popUpMaxSlider;
    public GameObject popUpVolumePanel;
    public SettingsWindow settingsWindow;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSettings audioSettings;
    [SerializeField] PopUpSlider popUpSlider;
    const string MIXER_MASTER = "MasterVolume";

    public float timeout = 5.0f;

    public void Start()
    {
        ToggleVolumePanel();
        ToggleVolumePanel();
    }

    void Update()
    {
        if (popUpSlider.popUpEnabled == true)
        {
            Invoke("DeactivatePopUp", timeout);
            popUpSlider.popUpEnabled = false;
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && popUpVolumePanel.activeInHierarchy)
        {
            popUpVolumePanel.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() && popUpVolumePanel.activeInHierarchy)
        {
            CancelInvoke("DeactivatePopUp");
            Invoke("DeactivatePopUp", timeout);
        }
    }

    public void ToggleVolumePanel()
    {
        if (settingsWindow.isActive == false)
        {
            popUpVolumePanel.SetActive(!popUpVolumePanel.activeInHierarchy);
        }
    }

    public void DeactivatePopUp()
    {
        popUpVolumePanel.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }
}
