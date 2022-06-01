using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ITakeDamageEnemyBehaviour : IBehaviourState
    {
        void ApplyDamage(Rigidbody attachedBody, int damage);
        void ApplyDamage(int damage);
    }
}