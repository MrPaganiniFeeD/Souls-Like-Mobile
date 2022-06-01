using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Inventory.Equipped;
using Infrastructure.Services;
using Inventory.InventoryWithSlots.Equipped;
using PlayerLogic.Animation;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;
using PlayerLogic.Stats;
using UnityEngine;

namespace Fabrics
{
    public class FabricPlayerStates : IFabricState
    {
        
        private IFactoryTransition _fabricTransitions;
        private IInputService _inputService;
    
        private PlayerStats _playerStats;
        private IWeaponSlot _leftWeaponSlot;
        private IWeaponSlot _rightWeaponSlot;
        private GameObject _player;
        private PlayerStateAnimator _animator;

        public FabricPlayerStates(IInputService inputService, IAttackButton leftAttackButton,
            IAttackButton rightHandAttackButton, IWeaponSlotInstaller inventoryEquipped, PlayerStats playerStats,
            IFactoryTransition fabricTransition, GameObject player)
        {
            _inputService = inputService;
            _leftWeaponSlot = inventoryEquipped.LeftHandWeaponSlot;
            _rightWeaponSlot = inventoryEquipped.RightHandWeaponSlot;
            _playerStats = playerStats;
            _fabricTransitions = fabricTransition;
            _player = player;
        }
        public PlayerState CreateState(PlayerStateInfo stateInfo, PlayerStateMachine playerStateMachine)
        {
            return stateInfo.State switch
            {
                TypePlayerState.Idle => new IdleState(_fabricTransitions.CreatTransitions(stateInfo.Transitions), _animator)
            
                //TypePlayerState.Move => ,
            
                /*TypePlayerState.AttackLeftHand => new LeftHandAttackState(
                    _player.GetComponent<IAttackBehaviour>(),
                    _player.GetComponent<IAttackAnimation>(),
                    _leftHandAttackButton,
                    _inputService,
                    _leftWeaponSlot,
                    _playerStats,
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine))*/
            
                /*TypePlayerState.AttackRightHand => new RightHandAttackState(
                    _player.GetComponent<IAttackBehaviour>(),
                    _player.GetComponent<IAttackAnimation>(),
                    _rightHandAttackButton,
                    _inputService,
                    _rightWeaponSlot,
                    _playerStats,
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine))*/,
            
                /*
                TypePlayerState.Attack => new AttackState(_player.GetComponent<IAttackBehaviour>(), 
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                    */
            
                /*
                TypePlayerState.Roll => new RollingState(_player.GetComponent<IRolling>(),
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine), 
                    _inputService),
                    */
            
                /*
                TypePlayerState.TakeDamage => new TakeDamageState(
                    _player.GetComponent<ITakeDamageBehaviour>(), 
                    _player.GetComponent<IDamageDetection>(),
                    _playerStats,
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                    */
            
                /*
                TypePlayerState.Death => new DeathPlayerState(_player.GetComponent<IDeathBehaviour>(), 
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                    */
            
                _ => new UnknownState()
            };
        }

        /*
        public SuperState CreateSuperState(ISuperStateInfo stateInfo, PlayerStateMachine basePlayerStateMachine)
        {
            return stateInfo.SuperState switch
            {
                TypePlayerSuperState.NormalConditions => new NormalConditionSuperState(
                    CreateStates(stateInfo.ChildrenStateInfos, basePlayerStateMachine),
                    _fabricTransitions.CreatTransitions(stateInfo.Transitions, basePlayerStateMachine),
                    basePlayerStateMachine),
            
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        */
        public List<PlayerState> CreateStates(IEnumerable<PlayerStateInfo> stateInfos,
            PlayerStateMachine playerStateMachine)
        {
            return stateInfos.Select(stateInfo => CreateState(stateInfo, playerStateMachine)).ToList();
        }

        /*
        public List<SuperState> CreateSuperStates(List<ISuperStateInfo> stateInfos, PlayerStateMachine basePlayerStateMachine)
        {
            return stateInfos.Select(stateInfo => CreateSuperState(stateInfo, basePlayerStateMachine)).ToList();
        }
    */
    }
}
