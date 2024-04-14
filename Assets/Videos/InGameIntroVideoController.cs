using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InGameIntroVideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    void Start()
    {
        // Subscribe to the loopPointReached event
        this.gameObject.SetActive(true);
        video.loopPointReached += OnVideoEnd;

        // Alternatively, you can subscribe to the stopped event
        // videoPlayer.stopped += OnVideoStopped;
    }

    // Method to be called when the video reaches its end
    void OnVideoEnd(VideoPlayer vp)
    {
        this.gameObject.SetActive(false);

        // Add your desired actions here
        // For example, you can load the next scene or display a UI element
    }
}
