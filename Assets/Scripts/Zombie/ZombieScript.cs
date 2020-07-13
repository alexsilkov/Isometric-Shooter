using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    private ManagerScript manager;

    private NavMeshAgent agent;
    private Transform player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
    }

    void Update()
    {
        agent.destination = player.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag.Equals("Player"))
        {
            manager.Lose();
        }
    }

    public void Death()
    {
        manager.WaveCheck();
        Destroy(gameObject);
    }
}
