using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMotion : MonoBehaviour
{   
    
    private NavMeshAgent agent;
    private ZombieLiving zombieLiving;
    private bool outOfRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieLiving = GetComponent<ZombieLiving>();
        zombieLiving.OnZombieRun += Run;
        zombieLiving.OnOutOfRange += OutOfRange;
        zombieLiving.OnShepsHere += ShepsHere;
    }

    void Update()
    {
        if (zombieLiving.target && !agent.pathPending)
            agent.SetDestination(zombieLiving.target.position);
    }

    private void ShepsHere(Transform sheps)
    {
        if (this)
        {
            zombieLiving.target = sheps;
            agent.SetDestination(zombieLiving.target.position);
        }
    }

    private void OutOfRange()
    {
        if(this) agent.speed = 0;
    }

    private void Run()
    {
        if (this) agent.speed *= 2;
    }

}
