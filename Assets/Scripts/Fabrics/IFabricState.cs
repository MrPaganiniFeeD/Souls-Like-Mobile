using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Hero.State;
using PlayerLogic.State;
using UnityEngine;
using UnityEngine.Events;
using Zenject.ReflectionBaking.Mono.CompilerServices.SymbolWriter;

public interface IFabricState
{
    /*
    BaseState CreateState(IStateInfo<Enum, Enum> stateInfo, PlayerStateMachine playerStateMachine);
    List<BaseState> CreateStates(List<IStateInfo> typeStates, PlayerStateMachine playerStateMachine);
    SuperState CreateSuperState(ISuperStateInfo stateInfo, PlayerStateMachine basePlayerStateMachine);
    List<SuperState> CreateSuperStates(List<ISuperStateInfo> typeStates, PlayerStateMachine basePlayerStateMachine);
*/
}
