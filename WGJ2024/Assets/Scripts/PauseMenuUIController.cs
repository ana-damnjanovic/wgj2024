using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUIController : MonoBehaviour
{
    public GameObject pauseMenu, resetButton;
    public AudioSource buttonClickSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            pauseMenu.SetActive(!pauseMenu.gameObject.activeSelf);

            resetButton.SetActive(!resetButton.gameObject.activeSelf);

            buttonClickSound.Play();
        }
    }
}
