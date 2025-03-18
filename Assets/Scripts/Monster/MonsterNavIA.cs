using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterNavAI : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    private NavMeshAgent agent;
    private float startWiwiSpeed;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        startWiwiSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = agent.remainingDistance;
        playerPos = player.transform.position;
        agent.destination = playerPos;

        //print(agent.remainingDistance);

        if (agent.remainingDistance > 100)
        {
            agent.speed = startWiwiSpeed*2;
        } else if (agent.remainingDistance < 75)
        {
            agent.speed = startWiwiSpeed;
        }
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
