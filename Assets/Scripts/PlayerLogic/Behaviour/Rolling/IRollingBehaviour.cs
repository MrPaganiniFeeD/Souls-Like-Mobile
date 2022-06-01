using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IRolling : IBehaviourState
{
    void Roll();
    void Rotate(Vector2 direction);
}
