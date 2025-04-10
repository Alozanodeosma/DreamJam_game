using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject Credits;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject introImage;

    public void MenuToSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }
    public void SettingsToMenu()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }
    public void SettingsToPlay()
    {
        videoPlayer.Play();
        introImage.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        
    }
    public void DefeatToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        Credits.SetActive(false);
    }
    public void OpenCredits() {
        Credits.SetActive(true);
    }
}
