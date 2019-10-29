using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieLiving : MonoBehaviour
{
    [HideInInspector]
    public Action OnZombieAttack;
    [HideInInspector]
    public Action OnZombieRun;
    [HideInInspector]
    public Action OnZombieDying;
    [HideInInspector]
    public Action OnOutOfRange;
    [HideInInspector]
    public Action<Transform> OnShepsHere;
    [HideInInspector]
    public Transform target;

    public ZombieConfiguration configuration;

    void Start()
    {
        ShepsLiving.OnIAmHere += (Transform sheps) =>
        {
            if (this)
            {
                float distance = (sheps.position - transform.position).magnitude;
                if ((distance < configuration.SmellRange))
                    OnShepsHere(sheps);
            }
        };
    }

    void Update()
    {
        if (target)
        {
            float distance = (target.position - transform.position).magnitude;
            if (distance < configuration.InRange) OnZombieRun();
            if (distance > configuration.OutRange) OnOutOfRange();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Sheps")
            OnZombieAttack();
        if (collision.collider.tag == "Fireball")
        {
            OnZombieDying();
            Debug.Log("Fireball");
        }
    }

   
}
