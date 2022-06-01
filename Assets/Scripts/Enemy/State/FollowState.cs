using System;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace Bot.State
{
    public class FollowState : BaseState
    {
        public override event Action<Enum> EndState;

        private IFollowBehaviour _followBehaviour;
        private IObservableTransform _observableTransform;
        
        public FollowState(IFollowBehaviour followBehaviour, IObservableTransform observableTransform, 
            List<ITransition> transitions) :
            base(followBehaviour, transitions)
        {
            _followBehaviour = followBehaviour;
            _observableTransform = observableTransform;
            IsLooping = false;
            IsBlockedState = false;
            TypeNextState = TypeEnemyState.Attack;
        }
        
        public override void Enter()
        {
            base.Enter();
            FollowToObservableTransform(_observableTransform.GetTransform());
            _observableTransform.OnChangePosition += FollowToObservableTransform;
        }

        public override void Update()
        {
            
        }
        public override void Exit()
        {
            base.Exit();
            _observableTransform.OnChangePosition -= FollowToObservableTransform;
        }

        protected override void OnEndBehaviour()
        {
            EndState?.Invoke(TypeNextState);;
        }

        private void FollowToObservableTransform(Transform targetTransform)
        {
            _followBehaviour.Follow(targetTransform);
        }
    }
}