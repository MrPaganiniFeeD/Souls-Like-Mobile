using System;
using System.Collections.Generic;
using Bot.Behaviour;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace DefaultNamespace.Stats
{
    public class DeathPlayerState : BaseState
    {
        public override event Action<Enum> EndState;
        private IDeathBehaviour _deathBehaviour;


        public DeathPlayerState(IDeathBehaviour deathBehaviour, List<ITransition> transitions) : base(deathBehaviour,
            transitions)
        {
            _deathBehaviour = deathBehaviour;
            IsLooping = false;
            IsBlockedState = true;
        }

        public override void Enter()
        {
            base.Enter();
            _deathBehaviour.Death();
        }
        public override void Update()
        {
            
        }

        protected override void OnEndBehaviour()
        {
            throw new NotImplementedException();
        }
    }
}