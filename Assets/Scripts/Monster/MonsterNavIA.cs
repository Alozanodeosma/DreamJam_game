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
    public float startWiwiSpeed;
    public float wiwiSprintSpeed;
    public float innerRange;
    public float outerRange;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        agent.speed = startWiwiSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerPos = player.transform.position;
        agent.destination = playerPos;
        distance = Vector3.Distance(playerPos,agent.transform.position);


        if (distance > outerRange)
         {
             agent.speed = wiwiSprintSpeed;
            print("sprint: " + agent.speed);
         } else if (distance < innerRange)
         {
             agent.speed = startWiwiSpeed;
            print("andar: " + agent.speed);
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
