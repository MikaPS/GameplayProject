using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Player1Movement player;

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Adjust the condition as needed
        {
            player.changeHealth(-10f);
        }
    }
}
