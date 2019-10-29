using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDying : MonoBehaviour
{
    [SerializeField]
    private GameObject dyingEffect;
    private ZombieLiving zombieLiving;

    private void Start()
    {
        zombieLiving = GetComponent<ZombieLiving>();
        zombieLiving.OnZombieDying += Dying;
    }

    void Dying()
    {
        if (gameObject)
        {
            Destroy(gameObject);
            Destroy(zombieLiving);
            GameObject effect = Instantiate(dyingEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
