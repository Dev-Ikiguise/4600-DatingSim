using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonBorder;
    public GameObject buttonText;
    public float timerDuration = 7f;
    private float timerStartTime;
    private bool buttonActive;
    private bool shownAtStart = false;

    void Start()
    {
        timerStartTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - timerStartTime >= timerDuration && !shownAtStart)
        {
            buttonText.SetActive(false);
            shownAtStart = true;

            timerStartTime = Time.time;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonBorder.SetActive(true);
        buttonText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonBorder.SetActive(false);
        buttonText.SetActive(false);
    }

    public void SetTextActive()
    {
        buttonText.SetActive(true);
        buttonActive = true;
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(10);
    }
}