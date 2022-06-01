using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;

public class PatrolState : BaseState
{
    public override event Action<Enum> EndState;
    private IPatrolBehaviour _patrolBehaviour;


    public PatrolState(IPatrolBehaviour patrolBehaviour, List<ITransition> transitions) : base(patrolBehaviour, transitions)
    {
        _patrolBehaviour = patrolBehaviour;
    }
    
    public override void Update()
    {
        _patrolBehaviour.Patrol();
    }

    protected override void OnEndBehaviour()
    {
        EndState?.Invoke(TypeNextState);
    }
}
