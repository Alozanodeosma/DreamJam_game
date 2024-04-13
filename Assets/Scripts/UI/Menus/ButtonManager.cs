using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
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
}
