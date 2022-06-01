using System;
using UnityEngine;

namespace Bot.Behaviour
{
    public interface ITakeDamageBehaviour : IBehaviourState
    {
        void ApplyDamage(Rigidbody attachedBody, int damage);
        void ApplyDamage(int damage);
    }
}