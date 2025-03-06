using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider volumeSlider; // Drag the UI Slider here

    void Start()
    {
        // Set the slider's value to the current AudioListener volume
        volumeSlider.value = AudioListener.volume;

        // Add a listener to update the volume when the slider value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value; // Adjust the global audio volume
    }
}
