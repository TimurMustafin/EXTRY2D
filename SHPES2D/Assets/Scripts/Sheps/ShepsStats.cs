using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsStats : MonoBehaviour
{
    
    [HideInInspector]
    public float Health;
    [SerializeField]
    private ShepsConfiguration shepsConfiguration;

    private void Start()
    {
        Health = shepsConfiguration.StartHealth;
    }
}
