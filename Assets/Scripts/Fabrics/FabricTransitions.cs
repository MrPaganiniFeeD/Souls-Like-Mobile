using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Hero.Transition;
using DefaultNamespace.Inventory.Equipped;
using Infrastructure.Services;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;
using PlayerLogic.Transition;

namespace Fabrics
{
    public class FactoryTransitions : IFactoryTransition, IDisposable
    {
        private IInputService _inputService;
        private readonly PlayerStateMachine _playerStateMachine;
    
        private IDamageDetection _damageDetection;
        private PlayerStats _playerStats;
        private ComboAttackTransition _comboAttackTransition;

        public FactoryTransitions(IInputService inputService, PlayerStateMachine playerStateMachine)
        {
            _inputService = inputService;
            _playerStateMachine = playerStateMachine;
        }
        public ITransition CreateTransition(TypeTransitions type)
        {
            switch (type)
            {
                case TypeTransitions.Idle :
                    return new IdleTransition(_inputService, _playerStateMachine);
                
                case TypeTransitions.Move :
                    return new MoveTransition(_inputService, _playerStateMachine);
            
                /*case TypeTransitions.ComboAttack :
                    _comboAttackTransition = new ComboAttackTransition(_playerStateMachine,
                        _leftHandAttackButton,
                        _rightHandAttackButton,
                        _playerStats);*/
                
                    WeaponSlotEventManager.EquipLeftHandWeapon += _comboAttackTransition.SetLeftHandWeapon;
                    WeaponSlotEventManager.UnequippedLeftHandWeapon += _comboAttackTransition.ClearLeftHandWeapon;
                
                    WeaponSlotEventManager.EquipRightHandWeapon += _comboAttackTransition.SetRightHandWeapon;
                    WeaponSlotEventManager.UnequippedRightHandWeapon += _comboAttackTransition.ClearRightHandWeapon;
                    return _comboAttackTransition;

                
                case TypeTransitions.Attack :
                    return new AttackTransition(_playerStateMachine, _inputService);

                /*
                case TypeTransitions.Rollig :
                    return new RollingTransition(_playerStateMachine, _rollButton, _playerStats);
                    */
            
                case TypeTransitions.TakeDamage :
                    return new TakeDamageTransition(_playerStateMachine, _damageDetection);
            
                /*
                case TypeTransitions.LeftHandAttack :
                    return new LeftHandAttackTransition(_playerStateMachine, _leftHandAttackButton, _playerStats);
                    */
            
                /*
                case TypeTransitions.RightHandAttack :
                    return new RightHandAttackTransition(_playerStateMachine, _rightHandAttackButton, _playerStats);
            */
            }
            return new UnknownTransition();
        }
    
        public List<ITransition> CreatTransitions(IEnumerable<TypeTransitions> typeTransitions) => 
            typeTransitions.Select(CreateTransition).ToList();

        public void Dispose()
        {
            if (_comboAttackTransition == null) return;
        
            WeaponSlotEventManager.EquipLeftHandWeapon -= _comboAttackTransition.SetLeftHandWeapon;
            WeaponSlotEventManager.UnequippedLeftHandWeapon -= _comboAttackTransition.ClearLeftHandWeapon;
                
            WeaponSlotEventManager.EquipRightHandWeapon -= _comboAttackTransition.SetRightHandWeapon;
            WeaponSlotEventManager.UnequippedRightHandWeapon -= _comboAttackTransition.ClearRightHandWeapon;
        }

    }
}

