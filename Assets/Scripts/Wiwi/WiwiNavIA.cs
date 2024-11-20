using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WiwiNavIA : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        agent.destination = playerPos;
    }


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
