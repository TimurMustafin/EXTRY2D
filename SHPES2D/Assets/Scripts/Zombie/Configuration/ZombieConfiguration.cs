using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Zombie Settings")]
public class ZombieConfiguration : ScriptableObject
{
    public float InRange;
    public float OutRange;
    public float SmellRange;
}
