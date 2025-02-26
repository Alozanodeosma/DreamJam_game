using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public GameObject objectToDeactivate; 
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
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
        if (objectToDeactivate != null)
        {
            // Activate the object
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogError("Object to activate reference is missing!");
        }
    }
}