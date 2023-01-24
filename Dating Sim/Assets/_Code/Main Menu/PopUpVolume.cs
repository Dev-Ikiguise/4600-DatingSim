using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpVolume : MonoBehaviour
{
    public Slider popUpMaxSlider;
    public GameObject popUpVolumePanel;

    public float timeout = 5.0f;

    void OnEnable()
    {
        Invoke("DeactivatePopUp", timeout);
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
}
