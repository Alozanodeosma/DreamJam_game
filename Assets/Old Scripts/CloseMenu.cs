using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the object to activate

    void Start()
    {
        // Get a reference to the button component attached to the game object
        Button button = GetComponent<Button>();

        // Check if a button component is found
        if (button != null)
        {
            // Add a listener to the button's onClick event
            button.onClick.AddListener(Activate);
        }
        else
        {
            Debug.LogError("Button component not found on the game object!");
        }
    }

    void Activate()
    {
        // Check if the object to activate is assigned
        if (objectToActivate != null)
        {
            // Activate the object
            objectToActivate.SetActive(false);
        }
        else
        {
            Debug.LogError("Object to activate reference is missing!");
        }
    }
}