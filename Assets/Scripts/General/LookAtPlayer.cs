using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            transform.LookAt(playerTransform);
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player has the tag 'Player'.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

