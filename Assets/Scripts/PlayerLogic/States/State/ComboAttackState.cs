using System;
using System.Collections.Generic;
using DefaultNamespace.Animation;
using Infrastructure.Services;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;
using UnityEngine;

namespace PlayerLogic.States.State
{
    public abstract class ComboAttackState : PlayerState
    {
        private IAttackBehaviour _attackBehaviour;
        private IAttackAnimation AttackAnimation;
        private IWeaponSlot WeaponSlot;

        private IAttackButton _attackButton;
        private IInputService _inputService;
        private PlayerStats _playerStats;
    
        private bool IsComboAttackReady;
        private int _numberAttack;
        private int _maxCountComboAttack = 5;

        protected ComboAttackState(IAttackBehaviour attackBehaviour,
            IAttackAnimation attackAnimation,
            IAttackButton attackButton,
            IInputService inputService,
            IWeaponSlot weaponSlot,
            PlayerStats playerStats,
            List<ITransition> transitions) : base(transitions)
        {
            _attackBehaviour = attackBehaviour;
            AttackAnimation = attackAnimation;
            _attackButton = attackButton;
            _inputService = inputService;
            _playerStats = playerStats;
            WeaponSlot = weaponSlot;

        }

        public override void Enter()
        {
            base.Enter();
            Subscribe();
            _numberAttack = 0;

            Attack();
        }
        public override void Exit()
        {
            base.Exit();
            UnSubscribe();
            ClearAnimationAttack();
        }
        private void Attack()
        {
            if (_playerStats.Stamina.TryUse(WeaponSlot.Weapon.WeaponInfo.StaminaCost) == false ||
                _playerStats.Mana.TryUse(WeaponSlot.Weapon.WeaponInfo.ManaCost) == false)
            {
                Debug.Log("End State");
                return;
            }

            Debug.Log("AttackData");
            _numberAttack++;
            WeaponSlot?.Weapon.Attack();
            _attackBehaviour.Attack(_inputService.Axis);
            ActivateAttackAnimation(WeaponSlot);
        }
        private void ActivateAttackAnimation(IWeaponSlot weaponSlot)
        {
            if (WeaponSlot.Weapon.WeaponInfo.TwoHand)
            {
                AttackAnimation.ActivateAttack();
                AttackAnimation.SetIsComboState(IsComboAttackReady);
                return;
            }
            switch (weaponSlot.EquippedItemType)
            {
                case EquippedItemType.WeaponLeftHand : 
                    AttackAnimation.ActivateLeftAttack();
                    AttackAnimation.SetIsLeftHandComboState(IsComboAttackReady);
                    break;
                case EquippedItemType.WeaponRightHand :
                    AttackAnimation.ActivateRightAttack();
                    AttackAnimation.SetIsRightHandComboState(IsComboAttackReady);
                    break;
            }
        }
        private void ClearAnimationAttack()
        {
            AttackAnimation.ResetAnimation();
        }
        private void OnClicked()
        {
            SetIsComboAttackReady(true);
        }
        private void SetIsComboAttackReady(bool comboReady)
        {
            IsComboAttackReady = comboReady;
        }
        private void Subscribe()
        {
            _attackBehaviour.EndBehaviour += EndAttackBehaviour;
            _attackButton.Clicked += OnClicked;
        }

        private void UnSubscribe()
        {
            _attackBehaviour.EndBehaviour -= EndAttackBehaviour;
            _attackButton.Clicked -= OnClicked;
        }
    
        private void EndAttackBehaviour()
        {
            if(IsComboAttackReady && _numberAttack < _maxCountComboAttack)
                Attack();
            
            SetIsComboAttackReady(false);
        }
    }
}
