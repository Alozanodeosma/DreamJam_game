using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabayagaManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //iniciar condicion de derrota
            //change scene to derrota
            SceneManager.LoadScene("DefeatScene");
        }
    }
}
