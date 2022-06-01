using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum TypeEnemyState
{
    None,
    Default,
    Idle,
    Patrol,
    Follow,
    Attack,
    ComboAttack,
    Roll,
    TakeDamage, 
    Death,
}
