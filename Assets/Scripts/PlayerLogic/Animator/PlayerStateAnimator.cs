using System;
using DefaultNarmespace.Player.AnimatorReporter;
using UnityEditor.Animations;
using UnityEngine;

namespace PlayerLogic.Animation
{
    public class PlayerStateAnimator : MonoBehaviour, IAnimationStateReader
    {
        public event Action ExitState;
        public event Action EnterState;

        public AnimatorState AnimatorState { get; }

        private Animator _animator;
        
        private static readonly int Moving = Animator.StringToHash("Moving");
        private static readonly int VelocityZ = Animator.StringToHash("Velocity Z");
        private static readonly int VelocityX = Animator.StringToHash("Velocity X");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int BackRolling = Animator.StringToHash("BackRolling");
        private static readonly int Rolling = Animator.StringToHash("Rolling");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Awake() => 
            _animator = GetComponent<Animator>();


        public void StartIdleAnimation() =>
            _animator.SetTrigger(Idle);
        public void StopIdleAnimation() =>
            _animator.ResetTrigger(Idle);
        
        
        public void StartMoveAnimation() => 
            _animator.SetBool(Moving, true);
        public void StopMoveAnimation() => 
            _animator.SetBool(Moving, false);
        
        
        public void UpdateVelocity(float x, float z)
        {
            _animator.SetFloat(VelocityX, x);
            _animator.SetFloat(VelocityZ, z);
        }

        
        public void StartBackRollAnimation() => 
            _animator.SetTrigger(BackRolling);
        public void StartRollAnimation() => 
            _animator.SetTrigger(Rolling);
        public void StopRollAnimation() => 
            _animator.ResetTrigger(Rolling);


        public void StopApplyDamageAnimation() => 
            _animator.ResetTrigger(TakeDamage);
        public void StartApplyDamageAnimation() => 
            _animator.SetTrigger(TakeDamage);


        public void StartDeathAnimation() => 
            _animator.SetTrigger(Dead);


        public void StartAttackAnimation() => 
            _animator.SetTrigger(Attack);
        public void StopAttackAnimation() => 
            _animator.ResetTrigger(Attack);

        public void OnStateEnter(AnimatorStateInfo stateInfo) => 
            EnterState?.Invoke();

        public void OnStateExit(AnimatorStateInfo stateInfo) =>
            ExitState?.Invoke();

        private void ShowStateInfo(AnimatorStateInfo stateInfo)
        {
            switch (stateInfo.tagHash)
            {
                    
            }
        }
    }
}