using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public GameObject HUD;
    private void OnEnable()
    {
        Time.timeScale = 0;
        HUD.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        HUD.SetActive(true);
    }
}
