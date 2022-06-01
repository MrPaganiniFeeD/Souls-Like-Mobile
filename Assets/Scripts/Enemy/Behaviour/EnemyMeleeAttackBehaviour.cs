using System;
using DefaultNamespace.Animation;
using Enemy.Animation;
using PlayerLogic.Behaviour.Attack;
using UnityEngine;

public class EnemyMeleeAttackBehaviour : MonoBehaviour, IAttackBehaviour,IAttackAnimation , IDamageColliderSwitcher
{
    public event Action EndBehaviour;
    public event Action OnOpenCollider;
    public event Action OnCloseCollider;

    [SerializeField] private float _attackDistance;
    public float Distance => _attackDistance;
    
    private EnemyStateAnimator _stateAnimator;

    private void Awake()
    {
        _stateAnimator = GetComponent<EnemyStateAnimator>();
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        ResetAnimation();
    }

    public void Attack(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }
    public void SetAnimations(IWeaponInfo weaponInfo)
    {
        _stateAnimator.StartAttackAnimation();
        _stateAnimator.StartComboAttackAnimation();
    }
    
    public void OpenCollider()
    {
        OnOpenCollider?.Invoke();
    }
    public void CloseCollider()
    {
        OnCloseCollider?.Invoke();
    }
    public void EndAttackAnimation()
    {
        EndBehaviour?.Invoke();
    }

    public void ActivateAttack()
    {
        _stateAnimator.StartAttackAnimation();
    }

    public void ActivateLeftAttack()
    {
        throw new NotImplementedException();
    }

    public void ActivateRightAttack()
    {
        throw new NotImplementedException();
    }

    public void SetIsLeftHandComboState(bool isComboState)
    {
        throw new NotImplementedException();
    }

    public void SetIsRightHandComboState(bool isComboState)
    {
        throw new NotImplementedException();
    }

    public void SetIsComboState(bool isComboState)
    {
        if(isComboState) _stateAnimator.StartComboAttackAnimation();
        else _stateAnimator.StopComboAttackAnimation();
    } 

    public void ResetAnimation()
    {
        _stateAnimator.StopAttackAnimation();
        _stateAnimator.StopComboAttackAnimation();
    }
}
