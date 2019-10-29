using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShepsUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    ShepsStats shepsStats;
    IUserInput userInput;

    private void Start()
    {
        shepsStats = GetComponent<ShepsStats>();
       
    }

    private void Update()
    {
        healthBar.value = shepsStats.Health;
    }
}
