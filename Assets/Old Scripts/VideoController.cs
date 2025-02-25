using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject itemToSetUnactive;
    [SerializeField] private GameObject itemToSetActive;
    void Start()
    {
        // Subscribe to the loopPointReached event
        this.video.SetActive(true);
        videoPlayer.loopPointReached += OnVideoEnd;

        // Alternatively, you can subscribe to the stopped event
        // videoPlayer.stopped += OnVideoStopped;
        if (itemToSetUnactive != null)
        {
            itemToSetUnactive.SetActive(false);
        }
    }

    // Method to be called when the video reaches its end
    void OnVideoEnd(VideoPlayer vp)
    {
        if (itemToSetActive != null)
        {
            itemToSetActive.SetActive(true);
        }

        video.SetActive(false);

        // Add your desired actions here
        // For example, you can load the next scene or display a UI element
    }

}
