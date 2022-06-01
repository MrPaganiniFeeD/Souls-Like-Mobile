using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.UI.Input;
using Infrastructure.Services;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;

public class RollingState : BaseState
{
    public override event Action<Enum> EndState;
    private IRolling _rolling;
    private IInputService _inputService;

    public RollingState(IRolling rolling,List<ITransition> transitions, IInputService inputService) 
        : base(rolling, transitions)
    {
        _rolling = rolling;
        _inputService = inputService;
        IsBlockedState = true;
        IsLooping = true;
        TypeNextState = TypePlayerState.Idle;
    }

    public override void Enter()
    {
        base.Enter();
        _rolling.Rotate(_inputService.Axis);
    }
    public override void Update()
    {
        _rolling.Roll();        
    }

    protected override void OnEndBehaviour()
    {
        EndState?.Invoke(TypeNextState);
    }
}
