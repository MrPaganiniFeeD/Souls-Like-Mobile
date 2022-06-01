using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;
using UnityEngine.Events;

public class JumpState : BaseState
{
    public override event Action<Enum> EndState;

    public override void Enter()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }

    protected override void OnEndBehaviour()
    {
        throw new NotImplementedException();
    }

    public JumpState(IBehaviourState behaviourState, List<ITransition> transitions) : base(behaviourState, transitions)
    {
    }
}
