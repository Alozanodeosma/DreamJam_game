using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject menu;
    void Start()
    {
        // Subscribe to the loopPointReached event
        video.loopPointReached += OnVideoEnd;

        // Alternatively, you can subscribe to the stopped event
        // videoPlayer.stopped += OnVideoStopped;
    }

    // Method to be called when the video reaches its end
    void OnVideoEnd(VideoPlayer vp)
    {
        menu.SetActive(true);
        this.gameObject.SetActive(false);

        // Add your desired actions here
        // For example, you can load the next scene or display a UI element
    }

}
