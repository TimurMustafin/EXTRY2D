using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsAnimation : MonoBehaviour
{
    public ShepsConfiguration shepsConfiguration;

    private Animator animator;
    private AnimatorStateInfo animatorState;
    private IUserInput userInput;
    private IInputSkills inputSkills;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        userInput = GetComponent<IUserInput>();
        inputSkills = GetComponent<IInputSkills>();

        inputSkills.OnShepsRun += Run;
        inputSkills.OnFire += () => { StartCoroutine(Fire()); };
        inputSkills.OnJump += () =>
        {
            if (animatorState.IsTag("Rest"))
                StartCoroutine(Jump());
        };
        inputSkills.OnRitual += () =>
        {
            if (animatorState.IsTag("Rest"))
                StartCoroutine(Ritual());
        };

        ShepsLiving.OnShepsDying += Dying;
    }

    void Update()
    {
        userInput.ReadInput();
        float Speed = Mathf.Abs(userInput.Moving) + Mathf.Abs(userInput.Turning);
        animator.SetFloat("Speed", Speed);
    }

    private void Run(bool run)
    {
        animator.SetBool("Run", run);
    }

    IEnumerator Ritual()
    {
        float timer = shepsConfiguration.RitualTime;
        animator.SetBool("Ritual", true);
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool("Ritual", false);
    }

    IEnumerator Jump()
    {
        float timer = shepsConfiguration.JumpTime;
        animator.SetBool("Jump", true);
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool("Jump", false);
    }

    IEnumerator Fire()
    {
        float timer = shepsConfiguration.FireTime;
        animator.SetBool("CutSpace", true);
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool("CutSpace", false);
    }

    private void Dying()
    {
        animator.SetBool("Dying", true);
    }

    
}
