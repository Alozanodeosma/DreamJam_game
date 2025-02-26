using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(Close);
        }
        else
        {
            Debug.LogError("Button component not found on the game object!");
        }
    }
    void Close()
    {
        Application.Quit();
    }
}
