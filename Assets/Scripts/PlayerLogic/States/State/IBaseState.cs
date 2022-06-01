using System;
using System.Collections.Generic;
using PlayerLogic.States.Transition;

namespace PlayerLogic.States.State
{
    public abstract class BaseState
    {
        public abstract event Action<Enum> EndState;
        public bool IsLooping { get; protected set; }
        public bool IsBlockedState { get; protected set; }

        protected Enum TypeNextState;
    
        protected readonly List<ITransition> Transitions;
        private readonly IBehaviourState _behaviourState;

        protected BaseState(IBehaviourState behaviourState, List<ITransition> transitions)
        {
            _behaviourState = behaviourState;
            Transitions = transitions;
        }

        protected BaseState()
        {
        
        }

        public virtual void Enter()
        {
            foreach (ITransition transition in Transitions)
                transition.Enter();
        
            _behaviourState.Enter();
            _behaviourState.EndBehaviour += OnEndBehaviour;
        }

        public virtual void Update()
        {
            foreach (ITransition transition in Transitions) 
                transition.Update();
        }

        public virtual void Exit()
        {
            foreach (var transition in Transitions) 
                transition.Exit();
        
            _behaviourState.Exit();
            _behaviourState.EndBehaviour -= OnEndBehaviour;
        }
        protected abstract void OnEndBehaviour();
    }
}