using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sheps Configuration")]
public class ShepsConfiguration : ScriptableObject
{
    public float StartHealth;
    public float MovingSpeed;
    public float TurningSpeed;
    public float JumpTime;
    public float JumpForce;
    public float RitualTime;
    public float SmellRadius;
    public int RunDamage;
    public float FireTime;
    public float FireDelay;
    public float FireballLifetime;
    public float FireballSpeed;
}
