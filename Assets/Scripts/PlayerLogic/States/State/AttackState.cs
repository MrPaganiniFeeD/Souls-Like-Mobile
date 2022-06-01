using System;
using System.Collections.Generic;
using Fabrics;
using PlayerLogic.Animation;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace PlayerLogic.States.State
{
    public class AttackState : PlayerState, IRotateState, IAttackState
    {
        private readonly PlayerStateAnimator _animator;
        private readonly PlayerStateMachine _playerStateMachine;
        public override float Duration { get; } = 0.5f;

        private FabricPlayerStates _fabricStates;
        
        public AttackState(List<ITransition> transitions, PlayerStateAnimator animator,
            PlayerStateMachine playerStateMachine) : base(transitions)
        {
            _animator = animator;
            _playerStateMachine = playerStateMachine;
            
        }

        public void Enter(IAttackStatePayloaded payloaded)
        {
            throw new NotImplementedException();
        }

        public override void Enter()
        {
            base.Enter();
            _animator.StartAttackAnimation();
        }
        public override void Exit()
        {
            base.Exit();
            _animator.StopAttackAnimation();
        }


        public void Rotate(Vector3 direction)
        {
            throw new NotImplementedException();
        }
        
    }

    public class ChangeAttackState : PlayerState
    {
        public override float Duration { get; }
        
        
    }


}
 