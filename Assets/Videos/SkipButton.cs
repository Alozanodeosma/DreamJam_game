using UnityEngine;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    public GameObject object1; // Reference to the first object to deactivate
    public GameObject object2; // Reference to the second object to deactivate
    public GameObject object3;
    public GameObject objectActive;
    public Button button; // Reference to the button component

    void Start()
    {
        // Check if a button is assigned
        if (button != null)
        {
            // Add a listener to the button's onClick event
            button.onClick.AddListener(Deactivate);
        }
        else
        {
            Debug.LogError("Button reference is missing!");
        }
    }

    void Deactivate()
    {
        // Check if objects are assigned
        if (object1 != null && object2 != null)
        {
            // Deactivate both objects
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            objectActive.SetActive(true);
        }
        else
        {
            Debug.LogError("One or both object references are missing!");
        }
    }
}