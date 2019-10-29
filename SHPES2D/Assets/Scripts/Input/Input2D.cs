using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input2D : MonoBehaviour, IUserInput, IInputSkills
{
    public event Action<bool> OnShepsRun;
    public event Action OnFire;
    public event Action OnJump;
    public event Action OnRitual;

    public float Moving { get; private set; }
    public float Turning { get; private set; }

    public void ReadInput()
    {
        Moving = Input.GetAxis("Vertical");
        Turning = 0;
        if (Input.GetKey(KeyCode.Mouse1))
            OnShepsRun(true);
        if (Input.GetKeyUp(KeyCode.Mouse1))
            OnShepsRun(false);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnFire();
        if (Input.GetKeyDown(KeyCode.Space))
            OnJump();
        if (Input.GetKeyDown("r"))
            OnRitual();
    }
}
