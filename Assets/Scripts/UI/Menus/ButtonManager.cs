using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject Credits;
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
        SceneManager.LoadScene("GameScene");
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
