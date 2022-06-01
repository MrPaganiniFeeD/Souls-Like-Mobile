using System;
using DefaultNamespace.Inventory.Equipped;
using PlayerLogic.State.StateMachine;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;

namespace DefaultNamespace.Hero.Transition
{
    public class LeftHandAttackTransition : ITransition, IDisposable
    {
        public PlayerStateMachine PlayerStateMachine { get; }
        private IAttackButton _attackButton;
        private PlayerStats _playerStats;
        private IWeaponInfo _weaponInfo;

        public LeftHandAttackTransition(PlayerStateMachine playerStateMachine, IAttackButton attackButton, PlayerStats playerStats)
        {
            _attackButton = attackButton;
            PlayerStateMachine = playerStateMachine;
            _playerStats = playerStats;
            WeaponSlotEventManager.EquipLeftHandWeapon += SetWeapon;
            WeaponSlotEventManager.UnequippedLeftHandWeapon += ResetWeapon;
        }

        private void ResetWeapon(IWeaponInfo weaponInfo)
        {
            if(_weaponInfo == weaponInfo)
                _weaponInfo = null;
        }

        private void SetWeapon(IWeaponInfo weaponInfo)
        {
            _weaponInfo = weaponInfo;
        }

        public void Enter()
        {
            _attackButton.Clicked += Transit;
        }

        public void Exit()
        {
            _attackButton.Clicked -= Transit;
        }

        public void Update()
        {
            
        }

        public void Transit()
        {
            if(_weaponInfo == null)
                return;

            if(_playerStats.Stamina.CheckValue(_weaponInfo.StaminaCost) &&
               _playerStats.Mana.CheckValue(_weaponInfo.ManaCost))
                PlayerStateMachine.SwitchState(TypePlayerState.AttackLeftHand);
        }

        public void Dispose()
        {
            WeaponSlotEventManager.EquipLeftHandWeapon -= SetWeapon;
            WeaponSlotEventManager.UnequippedLeftHandWeapon -= ResetWeapon;
        }
    }
}