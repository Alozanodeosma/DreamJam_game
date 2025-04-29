using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    private static bool paused = false;
    public TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle toggleFullScreen;
    void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        resolutionDropdown.value = ButtonManager.resolutionIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {
        if(!pauseMenu.activeInHierarchy){
            Time.timeScale = 0;
            AudioListener.pause = true;
            SliderMovement.paused = true;
            SliderWalk.paused = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            SliderMovement.paused = false;
            SliderWalk.paused = false;
            pauseMenu.SetActive(false);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        SliderMovement.paused = false;
        SliderWalk.paused = false;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
    }
    
    public void MainMenu()
    {
        SliderMovement.paused = false;
        SliderWalk.paused = false;
        Resume();
        SceneManager.LoadScene("MenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    private void OnResolutionChanged(int index)
    {
        // Determine the resolution based on the dropdown index
        switch (index)
        {
            case 0:
                // HD (1280x720)
                SetResolution(1280, 720);
                break;
            case 1:
                // Full HD (1920x1080)
                SetResolution(1920, 1080);
                break;
            case 2:
                // WXGA 
                SetResolution(1280, 800);
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
        ButtonManager.resolutionIndex = index;

    }

    void SetResolution(int width, int height)
    {
        // Apply the new resolution
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
