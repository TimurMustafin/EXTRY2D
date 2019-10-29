using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface IInputSkills 
{
    event Action<bool> OnShepsRun;
    event Action OnFire;
    event Action OnJump;
    event Action OnRitual;
}
