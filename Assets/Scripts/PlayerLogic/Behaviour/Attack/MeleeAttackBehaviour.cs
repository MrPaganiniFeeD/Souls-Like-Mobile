using System;
using DefaultNamespace.Animation;
using UnityEngine;

namespace PlayerLogic.Behaviour.Attack
{
    public class MeleeAttackBehaviour : MonoBehaviour, IAttackBehaviour, IAttackAnimation, IDamageColliderSwitcher
    {
        public event Action EndBehaviour;
        public event Action OnOpenCollider;
        public event Action OnCloseCollider;

        [SerializeField] private Animator _animator;
        [SerializeField] private float _attackDistance;
        public float Distance => _attackDistance;
        private IWeaponItem _weaponItem;
        private string _nameAnimation;
        private int _maxComboAttack = 5;

        private static readonly int IsLeftHandComboAttack = Animator.StringToHash("IsComboLeftHandAttack");
        private static readonly int IsRightHandComboAttack = Animator.StringToHash("IsComboRightHandAttack");
        private static readonly int IsComboAttack = Animator.StringToHash("IsComboAttack");
        private static readonly int AttackTrigger = Animator.StringToHash("AttackData");
        private static readonly int LeftHandAttackTrigger = Animator.StringToHash("LeftHandAttack");
        private static readonly int RightHandAttackTrigger = Animator.StringToHash("RightHandAttack");
    
        public void Enter()
        {
        }

        public void Exit()
        {
            OnCloseCollider?.Invoke();
            ResetAnimation();
        }

        public void Attack(Vector3 direction) => Rotate(direction);

        public void ActivateLeftAttack() =>
            _animator.SetTrigger(LeftHandAttackTrigger);

        public void ActivateRightAttack() => 
            _animator.SetTrigger(RightHandAttackTrigger);

        public void ActivateAttack() => 
            _animator.SetTrigger(AttackTrigger);

        public void SetIsLeftHandComboState(bool isComboState) => 
            _animator.SetBool(IsLeftHandComboAttack, isComboState);

        public void SetIsRightHandComboState(bool isComboState) => 
            _animator.SetBool(IsRightHandComboAttack, isComboState);

        public void SetIsComboState(bool isComboState)
        { 
            _animator.SetBool(IsComboAttack, isComboState);
        }

        public void ResetAnimation(IWeaponInfo weaponInfo)
        {
            _animator.SetBool(IsLeftHandComboAttack, false);
            _animator.ResetTrigger(AttackTrigger);
        }

        public void ResetAnimation()
        {
            _animator.SetBool(IsLeftHandComboAttack, false);
            _animator.SetBool(IsRightHandComboAttack, false);
            _animator.SetBool(IsComboAttack, false);
            _animator.ResetTrigger(AttackTrigger);
            _animator.ResetTrigger(LeftHandAttackTrigger);
            _animator.ResetTrigger(RightHandAttackTrigger);
        }

        public void OpenCollider()
        {
            OnOpenCollider?.Invoke();
        }

        public void CloseCollider() => 
            OnCloseCollider?.Invoke();

        public void EndAttack() => 
            EndBehaviour?.Invoke();

        private void Rotate(Vector3 direction)
        {
            if(direction == Vector3.zero)
                return;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
