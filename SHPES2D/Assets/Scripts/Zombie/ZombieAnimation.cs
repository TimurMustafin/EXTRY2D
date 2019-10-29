using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private ZombieLiving zombieLiving;
    private bool isRuning;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        zombieLiving = GetComponent<ZombieLiving>();
        zombieLiving.OnZombieAttack += Attack;
        zombieLiving.OnZombieRun += Run;
        zombieLiving.OnOutOfRange += OutOfRange;
    }

    private void OutOfRange()
    {
        if (gameObject)
        {
            animator.SetBool("Run", false);
            animator.SetFloat("Speed", 0);
        }
       
    }

    private void Run()
    {
        if(gameObject)
            animator.SetBool("Run", true);
    }

    void Update()
    {
        if (gameObject)
        {
            float Speed = agent.velocity.magnitude;
            if (Speed != 0 && !isRuning)
                animator.SetFloat("Speed", Speed);

        }
        
    }

    private void Attack()
    {
        if(gameObject) 
            animator.SetBool("Attack", true);
    }
}
