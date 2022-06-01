using System;
using UnityEngine;

namespace Bot.Behaviour
{
    public class IdleEnemyBehaviour : MonoBehaviour, IIdleBehaviour
    {
        public event Action EndBehaviour;

        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Idle = Animator.StringToHash("Idle");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void Enter()
        {
            _animator.SetTrigger(Idle);
            _animator.SetFloat(Speed, 0);
        }
        public void Exit()
        {
            _animator.ResetTrigger(Idle);               
        }
        public void Idling()
        {
            
        }
    }
}