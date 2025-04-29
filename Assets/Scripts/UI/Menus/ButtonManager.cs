using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;

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
    [SerializeField] private GameObject canvasOptions;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle toggleFullScreen;
    public GameObject canvas;
    public static int resolutionIndex = 0;
    public static bool isFullScreen = true;

    private void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        isFullScreen = Screen.fullScreen;
        resolutionDropdown.value = resolutionIndex;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            Options();
            //get screen resolution and fullscreen mode
            //game window resolution
        }

    }
    
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

    public void Retry()
    {
        SceneManager.LoadScene("Escenario V2");
    }

    public void Options()
    {
        if (!canvasOptions.activeInHierarchy)
        {
            canvas.SetActive(false);
            canvasOptions.SetActive(true);
        }
        else
        {
            canvas.SetActive(true);
            canvasOptions.SetActive(false);
        }
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

    private void OnResolutionChanged(int index)
    {
        // Determine the resolution based on the dropdown index
        switch (index)
        {
            case 0:
                // HD (1280x720)
                SetResolution(1920, 1080);
                break;
            case 1:
                // Full HD (1920x1080)
                SetResolution(1920, 1080);
                break;
            case 2:
                // WXGA 
                SetResolution(1280, 720);
                break;
            case 3:
                // QHD 
                SetResolution(2560, 1440);
                break;
            case 4:
                // 4K 
                SetResolution(3840, 2160);
                break;
            default:
                SetResolution(1920, 1080); // Default to Full HD if something unexpected happens
                break;
        }
                resolutionIndex = index;

    }
    void SetResolution(int width, int height)
    {
        // Apply the new resolution
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        isFullScreen = Screen.fullScreen;
    }

}
