using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartCinematic : MonoBehaviour
{
    [SerializeField] GameObject videoFinal;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject bicho;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void OnTriggerEnter(Collider other)
    {

        // Check if the entering object is the player
        if (other.CompareTag("Player"))
        {
            //get the player component videoFunal

            videoPlayer.gameObject.SetActive(true);
            videoFinal.SetActive(true);
        }

    }
    void OnVideoEnd(VideoPlayer vp)
    {
        //load scene
        SceneManager.LoadScene("MenuScene");
        // Add your desired actions here
        // For example, you can load the next scene or display a UI element
    }

}