using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        // Get a reference to the button component attached to the game object
        Button button = GetComponent<Button>();

        // Check if a button component is found
        if (button != null)
        {
            // Add a listener to the button's onClick event
            button.onClick.AddListener(Close);
        }
        else
        {
            Debug.LogError("Button component not found on the game object!");
        }
    }

    void Close()
    {
        // Close the application
        Application.Quit();
    }
}
