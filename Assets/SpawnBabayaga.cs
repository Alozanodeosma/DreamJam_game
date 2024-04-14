using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBabayaga : MonoBehaviour
{
    [SerializeField] private GameObject babayaga;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //spawn babayaga
            babayaga.SetActive(true);
            gameObject.SetActive(false);

        }
    }

}
