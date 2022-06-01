using System;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace Bot.State
{
    public class IdleEnemyState : BaseState
    {
        public override event Action<Enum> EndState;
        private IIdleBehaviour _idleBehaviour;

        public IdleEnemyState(IIdleBehaviour idleBehaviour, List<ITransition> transitions) : base(idleBehaviour, transitions)
        {
            _idleBehaviour = idleBehaviour;
            IsLooping = false;
            IsBlockedState = false;
        }

        public override void Enter()
        {
            base.Enter();
            _idleBehaviour.Idling();
        }
        public override void Update()
        {
            
        }
        protected override void OnEndBehaviour()
        {
            EndState?.Invoke(TypeNextState);;
        }
    }
}