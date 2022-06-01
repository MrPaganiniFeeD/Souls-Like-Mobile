using System;
using System.Collections.Generic;
using Bot.Behaviour;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;

namespace Bot.State
{
    public class DeathEnemyState : BaseState
    {
        public override event Action<Enum> EndState;
        private IDeathBehaviour _deathBehaviour;


        public DeathEnemyState(IDeathBehaviour deathBehaviour, List<ITransition> transitions) : base(deathBehaviour, transitions)
        {
            _deathBehaviour = deathBehaviour;
            IsBlockedState = true;
            IsLooping = false;
        }

        public override void Enter()
        {
            base.Enter();
            _deathBehaviour.Death();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            base.Exit();
        }

        protected override void OnEndBehaviour()
        {
            EndState?.Invoke(TypeNextState);;
        }
    }
}