using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject phoneElement;
    public GameObject hotbarElement;
    public GameObject showHotbarElement;
    private bool gamePaused = false;
    private bool hotbarActive = true;

    private void Start()
    {
        showHotbarElement.SetActive(false);
        phoneElement.SetActive(false);
    }

    void Update()
    {
        // Toggle the UI element on button press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePhone()
    {
        if (phoneElement != null)
        {
            phoneElement.SetActive(!phoneElement.activeSelf);
        }
    }

    public void ToggleHotbar()
    {
        if (hotbarActive == false)
        {
            hotbarElement.SetActive(true);
            showHotbarElement.SetActive(false);
            hotbarActive = true;
        }
        else if (hotbarActive == true)
        {
            hotbarElement.SetActive(false);
            showHotbarElement.SetActive(true);
            hotbarActive = false;
        }
    }

    public void TogglePause()
    {
        // Toggle the game's pause state
        if (!gamePaused)
        {
            Time.timeScale = 0f; // Pause the game
            gamePaused = true;
            Debug.Log("Paused");
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            gamePaused = false;
            Debug.Log("Unpaused");
        }
    }
}
