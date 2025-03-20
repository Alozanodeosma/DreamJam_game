using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoolActivator : MonoBehaviour
{
    public GameObject farolaWiwi; // Referencia al GameObject que contiene el componente BlinkingAdelanto
    public bool boolWiwi;
    private BlinkingAdelanto blinkingAdelanto;

    void Start()
    {
        if (farolaWiwi != null)
        {
            blinkingAdelanto = farolaWiwi.GetComponent<BlinkingAdelanto>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && blinkingAdelanto != null)
        {
            blinkingAdelanto.wiwiTrigger = boolWiwi;
        }
    }
}
