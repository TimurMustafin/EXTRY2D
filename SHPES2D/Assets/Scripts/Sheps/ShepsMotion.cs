using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsMotion : MonoBehaviour
{
    public ShepsConfiguration shepsConfiguration;
   


    private IUserInput userInput;
    private IInputSkills inputSkills;
    private ShepsStats shepsStats;
    private Rigidbody rigidbody;
    private float Speed;
    private bool isDying;
    private bool isFiring;


    private void Start()
    {
        Speed = shepsConfiguration.MovingSpeed;
        rigidbody = GetComponent<Rigidbody>();
        userInput = GetComponent<IUserInput>();
        inputSkills = GetComponent<IInputSkills>();

        inputSkills.OnShepsRun += Run;
        inputSkills.OnJump += () => StartCoroutine(Jump());
        inputSkills.OnFire += () => StartCoroutine(Fire());

        ShepsLiving.OnShepsDying += () => { isDying = true; };

        shepsStats = GetComponent<ShepsStats>();
    }

    IEnumerator Jump()
    {
        Debug.Log("Jump!");
        float timer = 0.8f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        rigidbody.AddForce(transform.up * shepsConfiguration.JumpForce, ForceMode.Impulse);
    }

    IEnumerator Fire()
    {
        float timer = shepsConfiguration.FireTime;
        isFiring = true;

        #region Timer
        while (timer > 0)
        {
            Speed = 0;
            timer -= Time.deltaTime;
            yield return null;
        }
        #endregion

        isFiring = false;
        Speed = shepsConfiguration.MovingSpeed;
    }

    private void Update()
    {
        if (isDying) return;
        userInput.ReadInput();
        Move();
    }

    private void Move()
    {
        Vector3 direction = Vector3.right * userInput.Moving;
        transform.position += direction * Speed * Time.deltaTime;
        if(direction.magnitude != 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), shepsConfiguration.TurningSpeed);
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.forward), shepsConfiguration.TurningSpeed);
    }

    private void Run(bool run)
    {   
        if(!isFiring)
        {
            if (run) 
            {
                Speed = shepsConfiguration.MovingSpeed * 4;
                shepsStats.Health -= shepsConfiguration.RunDamage * Time.deltaTime;
            }
            else Speed = shepsConfiguration.MovingSpeed;
        }
    }


}
