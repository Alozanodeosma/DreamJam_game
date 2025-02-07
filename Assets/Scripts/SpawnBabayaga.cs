using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBabayaga : MonoBehaviour
{
    [SerializeField] private GameObject babayaga;
    [SerializeField] private GameObject textBabayaga;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //spawn babayaga
            textBabayaga.SetActive(true);
            gameObject.SetActive(false);

        }
    }

}
