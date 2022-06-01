using System;
using Bot.Behaviour;
using UnityEngine;

namespace DefaultNamespace.Hero.Behaviour.TakeDamage
{
    public class TakeDamageBehaviour : MonoBehaviour, ITakeDamageBehaviour
    {
        public event Action EndBehaviour;
        
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Animator _animator;
        private static readonly int TakeDamageAnimation = Animator.StringToHash("TakeDamage");
        private static readonly int Dead = Animator.StringToHash("Dead");


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            _rigidbody.velocity = Vector3.zero;
        }


        public void ApplyDamage(Rigidbody attachedBody, int damage)
        {
            _animator.SetTrigger(TakeDamageAnimation);
            CalculatePhysics(attachedBody);
        }

        public void ApplyDamage(int damage)
        {
        }

        private void CalculatePhysics(Rigidbody attachedBody)
        {
            var direction = _transform.position - attachedBody.position;
            direction.y = 0;
            _rigidbody.AddForce(direction.normalized * 2, ForceMode.Impulse);
        }
        
        public void EndTakeDamageAnimation()
        {
            EndBehaviour?.Invoke();
        }
    }
}