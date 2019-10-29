using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface IUserInput 
{
    
    float Moving { get; }
    float Turning { get; }

    void ReadInput();
}
