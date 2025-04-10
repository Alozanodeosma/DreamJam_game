using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuVideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject itemToSetUnactive;
    [SerializeField] private GameObject itemToSetActive;
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Pause();
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Escenario V2");
    }

}
