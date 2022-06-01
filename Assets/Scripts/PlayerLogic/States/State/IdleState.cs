using System.Collections.Generic;
using PlayerLogic.Animation;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace PlayerLogic.States.State
{
    
    public class IdleState : PlayerState, IIdleState
    {
        private readonly PlayerStateAnimator _animator;
        public override float Duration { get; } = 0;


        public IdleState(List<ITransition> transitions, PlayerStateAnimator animator) : base(transitions)
        {
            _animator = animator;
        }

        public override void Enter()
        {
            base.Enter();
            _animator.StartIdleAnimation();
            Debug.Log("Enter IdleState");
        }
        public override void Exit()
        {
            base.Exit();
            _animator.StopIdleAnimation();
        }
    }
}
