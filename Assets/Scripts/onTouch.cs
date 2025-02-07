using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTouch : MonoBehaviour
{
    public GameObject sonidoAmb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")   
        {
            //make the sonidoAmb audio source component volume 1
            sonidoAmb.GetComponent<AudioSource>().volume = 1;
            this.gameObject.SetActive(false);
        }
    }
}
