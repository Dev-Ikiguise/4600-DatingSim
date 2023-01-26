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

    [SerializeField] AudioMixer mixer;
    const string MIXER_MASTER = "MasterVolume";

    public float timeout = 5.0f;

    void OnEnable()
    {
        Invoke("DeactivatePopUp", timeout);
        popUpMaxSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    void Update()
    {
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
        popUpVolumePanel.SetActive(!popUpVolumePanel.activeInHierarchy);
    }

    private void DeactivatePopUp()
    {
        popUpVolumePanel.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }
}
