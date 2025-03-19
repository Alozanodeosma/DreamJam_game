using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject SliderMovement;
    [SerializeField] private GameObject SliderRotation;

    public void OnButtonPressed()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0;

            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
