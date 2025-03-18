using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnBabayaga : MonoBehaviour
{
    [SerializeField] private GameObject babayaga;
    [SerializeField] private TMP_Text introTextComponent;
    private float textSpeed = 0.1f;
    private Queue<string> text;

    private void Start()
    {
        text = new Queue<string>();
        text.Enqueue("Something wicked this way comes");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !babayaga.activeInHierarchy)
        {
            //spawn babayaga
            babayaga.SetActive(true);
            StartCoroutine(TextCoroutine.AppearText(introTextComponent, textSpeed, text));
        }
    }

}
