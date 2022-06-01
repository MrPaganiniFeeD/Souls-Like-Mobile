using System;
using DefaultNamespace.Animation;
using UnityEditor.Animations;
using UnityEngine;

namespace DefaultNarmespace.Player.AnimatorReporter
{
    public interface IAnimationStateReader
    {
        event Action ExitState;
        event Action EnterState;
        
        AnimatorState AnimatorState { get; }

        void OnStateEnter(AnimatorStateInfo stateInfo);
        void OnStateExit(AnimatorStateInfo stateInfo);
    }
}