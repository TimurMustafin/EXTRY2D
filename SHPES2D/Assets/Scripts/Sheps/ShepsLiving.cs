using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShepsLiving : MonoBehaviour
{
    public static Action<Transform> OnIAmHere;
    public static Action OnShepsDying;
    public ShepsConfiguration configuration;

    void Start()
    {
        
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, configuration.SmellRadius);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Zombie")
                OnIAmHere(transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            OnShepsDying();
        }
           
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, configuration.SmellRadius);
    }


}
