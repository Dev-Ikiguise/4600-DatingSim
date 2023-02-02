using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonBorder;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonBorder.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonBorder.SetActive(false);
    }
}