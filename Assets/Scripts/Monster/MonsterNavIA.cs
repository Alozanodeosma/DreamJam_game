using System.Collections;
using System.Collections.Generic;
using Steamworks.Data;
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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = startWiwiSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        agent.destination = playerPos;
        distance = Vector3.Distance(playerPos, agent.transform.position);

        //esto se podria haber hecho bien, con las cosas de IA
        if (distance > outerRange)
        {
            agent.speed = wiwiSprintSpeed;
            animator.speed = 1.22f;
            //print("sprint: " + agent.speed);
        }
        else if (distance < innerRange)
        {
            agent.speed = startWiwiSpeed;
            animator.speed = 0.6f;
            //print("andar: " + agent.speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SteamAchievementsManager.UnlockAchievement(SteamAchievementsManager.archDeath);
            SceneManager.LoadScene("DefeatScene");
        }
    }


}
