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
    
    void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
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
        pauseMenu.SetActive(false);
    }
    
    public void Exit()
    {
        SliderMovement.paused = false;
        SliderWalk.paused = false;
        SceneManager.LoadScene("MenuScene");
    }
    private void OnResolutionChanged(int index)
    {
        // Determine the resolution based on the dropdown index
        switch (index)
        {
            case 0:
                // Full HD (1920x1080)
                SetResolution(1920, 1080);
                break;
            case 1:
                // WXGA 
                SetResolution(1280, 800);
                break;
            case 2:
                // QHD 
                SetResolution(2560, 1440);
                break;
            case 3:
                // 4K 
                SetResolution(3840, 2160);
                break;
            default:
                SetResolution(1920, 1080); // Default to Full HD if something unexpected happens
                break;
        }

        void SetResolution(int width, int height)
        {
            // Apply the new resolution
            Screen.SetResolution(width, height, Screen.fullScreen);
            Debug.Log($"Resolution set to: {width}x{height}");
        }
    }
}
