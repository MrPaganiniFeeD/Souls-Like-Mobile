using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bot.Transition;
using DefaultNamespace;
using DefaultNamespace.Bot.Data;
using Fabrics;
using PlayerLogic.State.StateMachine;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using UnityEngine;
using Zenject;

[Serializable]
public class FactoryEnemyTransition : IFactoryTransition
{
    /*
    private Transform _selfTransform;
    private IObservableTransform _targetObservableTransform;
    private IObservableTransform _selfObservableTransform;
    private ITakeDamageEnemyBehaviour _takeDamageEnemyBehaviour;
    private IDamageDetection _damageDetection;
    private IAttackBehaviour _attackBehaviour;
    private IFollowInfo _followInfo;
    
    public FactoryEnemyTransition(GameObject gameObject, IObservableTransform observableTransform)
    {
        _takeDamageEnemyBehaviour = gameObject.GetComponent<ITakeDamageEnemyBehaviour>();
        _damageDetection = gameObject.GetComponent<IDamageDetection>();
        _selfObservableTransform = gameObject.GetComponent<IObservableTransform>();
        _selfTransform = gameObject.GetComponent<Transform>();
        _attackBehaviour = gameObject.GetComponent<IAttackBehaviour>();
        _targetObservableTransform = observableTransform;
    }
    
    public ITransition CreateTransition(Enum typeTransition, PlayerStateMachine playerStateMachine)
    {
        return typeTransition switch
        {
            TypeEnemyTransition.Idle => new IdleEnemyTransition(),
            TypeEnemyTransition.Follow => new FollowTransition(playerStateMachine, _targetObservableTransform, _selfTransform),
            TypeEnemyTransition.Patrol => new PatrolTransition(),
            TypeEnemyTransition.TakeDamage => new TakeDamageEnemyTransition(playerStateMachine, _damageDetection),
            TypeEnemyTransition.Attack => new AttackEnemyTransition(playerStateMachine, _targetObservableTransform,
                _selfObservableTransform,
                _attackBehaviour),
            TypeEnemyTransition.Roll => new RollEnemyTransition(),
            TypeEnemyTransition.Death => new DeathEnemyTransition(playerStateMachine, _damageDetection),
            
            _ => new UnknownTransition()
        };    
    }
    public List<ITransition> CreatTransitions(List<Enum> typeTransitions, PlayerStateMachine playerStateMachine)
    {
         return typeTransitions.Select(typeTransition => CreateTransition(typeTransition, playerStateMachine)).ToList();
    }*/
    
    public ITransition CreateTransition(TypeTransitions typeTransitions)
    {
        throw new NotImplementedException();
    }

    public List<ITransition> CreatTransitions(IEnumerable<TypeTransitions> typeTransitions)
    {
        throw new NotImplementedException();
    }
}
