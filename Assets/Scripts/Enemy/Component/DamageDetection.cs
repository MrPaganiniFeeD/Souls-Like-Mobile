using System;
using UnityEngine;

namespace Enemy.Component
{
    public class DamageDetection : MonoBehaviour, IDamageDetection
    {
        public event Action<Rigidbody, int> TakingBodyDamage;
        public event Action<int> TakingDamage;
        public event Action ReceivedDamage;

        public void ApplyDamage(Rigidbody attachedRigidbody, int damage)
        {
            ReceivedDamage?.Invoke();
            TakingBodyDamage?.Invoke(attachedRigidbody, damage);
        }
        public void ApplyDamage(int damage)
        {
            ReceivedDamage?.Invoke();
            TakingDamage?.Invoke(damage);
        }
    
    }
}
