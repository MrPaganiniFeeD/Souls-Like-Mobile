using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Animation;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEditorInternal;
using UnityEngine;

public class AttackEnemyState : BaseState
{
    public override event Action<Enum> EndState;
    
    private IAttackBehaviour _attackBehaviour;
    private IAttackAnimation _attackAnimation;
    private IObservableTransform _observableTransform;
    private Transform _transform;
    private Vector3 _targetPosition;
    
    public AttackEnemyState(IAttackBehaviour attackBehaviour,IAttackAnimation attackAnimation, 
        IObservableTransform observableTransform, Transform transform,
        List<ITransition> transitions) : base(attackBehaviour, transitions)
    {
        _attackBehaviour = attackBehaviour;
        _attackAnimation = attackAnimation;
        _observableTransform = observableTransform;
        _transform = transform;
        IsBlockedState = true;
        IsLooping = false;
        TypeNextState = TypeEnemyState.Follow;
    }
    public override void Enter()
    {
        base.Enter();
        _targetPosition = _observableTransform.GetTransform().position;
        Attack();
    }
    private void Attack()
    {
        var direction = _targetPosition - _transform.position;
        _attackBehaviour.Attack(direction);
        _attackAnimation.ActivateAttack();
    }

    protected override void OnEndBehaviour()
    {
        _targetPosition = _observableTransform.GetTransform().position;
        if (Vector3.Distance(_transform.position, _targetPosition) < _attackBehaviour.Distance)
            Attack();
        else
            EndState?.Invoke(TypeNextState);
    }
}
