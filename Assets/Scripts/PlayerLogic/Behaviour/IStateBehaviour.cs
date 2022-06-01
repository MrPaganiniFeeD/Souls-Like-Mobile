using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBehaviourState
{
    event Action EndBehaviour;
    
    void Enter();
    void Exit();
}
