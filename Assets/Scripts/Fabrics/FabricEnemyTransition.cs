using System;
using System.Collections.Generic;
using System.Linq;
using Bot.Transition;
using Fabrics;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using UnityEngine;

[Serializable]
public class FactoryEnemyTransition : IFactoryTransition
{
    
    private Transform _selfTransform;
    private IObservableTransform _targetObservableTransform;
    private IObservableTransform _selfObservableTransform;
    private IDamageDetection _damageDetection;

    public FactoryEnemyTransition(GameObject gameObject, IObservableTransform observableTransform)
    {
        _damageDetection = gameObject.GetComponent<IDamageDetection>();
        _selfObservableTransform = gameObject.GetComponent<IObservableTransform>();
        _selfTransform = gameObject.GetComponent<Transform>();
        _targetObservableTransform = observableTransform;
    }
    
    public ITransition CreateTransition(Enum typeTransition, PlayerStateMachine playerStateMachine)
    {
        return typeTransition switch
        {
            TypeEnemyTransition.Idle => new IdleEnemyTransition(),
            TypeEnemyTransition.Patrol => new PatrolTransition(),
            TypeEnemyTransition.Roll => new RollEnemyTransition(),

            _ => new UnknownTransition()
        };    
    }
    public List<ITransition> CreatTransitions(List<Enum> typeTransitions, PlayerStateMachine playerStateMachine)
    {
         return typeTransitions.Select(typeTransition => CreateTransition(typeTransition, playerStateMachine)).ToList();
    }
    
    public ITransition CreateTransition(TypeTransitions typeTransitions)
    {
        throw new NotImplementedException();
    }

    public List<ITransition> CreatTransitions(IEnumerable<TypeTransitions> typeTransitions)
    {
        throw new NotImplementedException();
    }
}
