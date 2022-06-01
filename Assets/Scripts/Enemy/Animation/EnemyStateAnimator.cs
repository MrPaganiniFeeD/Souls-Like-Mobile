using System;
using DefaultNarmespace.Player.AnimatorReporter;
using UnityEditor.Animations;
using UnityEngine;

namespace Enemy.Animation
{
    public class EnemyStateAnimator : MonoBehaviour, IAnimationStateReader
    {
        public event Action ExitState;
        public event Action EnterState;
        
        public AnimatorState AnimatorState { get; }
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Follow = Animator.StringToHash("Follow");
        private static readonly int Patrol = Animator.StringToHash("Patrol");
        private static readonly int ComboAttack = Animator.StringToHash("ComboAttack");
        private static readonly int Attack = Animator.StringToHash("AttackData");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private static readonly int Dead = Animator.StringToHash("Dead");

        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void StartIdleAnimation()
        {
            
        }

        public void StartFollowAnimation(float speed)
        {
            _animator.SetTrigger(Follow);
            SetSpeed(speed);
        }

        public void StopFollowAnimation()
        {
            _animator.ResetTrigger(Follow);
            SetSpeed(0);
        }

        public void StartPatrolAnimation(float speed)
        {
            _animator.SetTrigger(Patrol);
            SetSpeed(speed);
        }

        public void StopPatrolAnimation()
        {
            _animator.ResetTrigger(Patrol);
            SetSpeed(0);
        }

        public void StartAttackAnimation() => 
            _animator.SetTrigger(Attack);

        public void StopAttackAnimation() => 
            _animator.ResetTrigger(Attack);

        public void StartComboAttackAnimation() => 
            _animator.SetBool(ComboAttack, true);

        public void StopComboAttackAnimation() => 
            _animator.SetBool(ComboAttack, false);

        public void StartDieAnimation() => 
            _animator.SetTrigger(Dead);

        public void StopDieAnimation() => 
            _animator.ResetTrigger(Dead);

        public void StartApplyDamageAnimation() => 
            _animator.SetTrigger(TakeDamage);

        public void OnStateEnter(AnimatorStateInfo stateInfo) => 
            throw new NotImplementedException();

        public void OnStateExit(AnimatorStateInfo stateInfo) => 
            throw new NotImplementedException();

        private void SetSpeed(float speed) =>
            _animator.SetFloat(Speed, speed);
    }
}