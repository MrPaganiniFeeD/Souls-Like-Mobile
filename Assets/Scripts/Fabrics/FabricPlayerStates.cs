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

        public FabricPlayerStates(IInputService inputService, IWeaponSlotInstaller inventoryEquipped, PlayerStats playerStats,
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
                TypePlayerState.Idle => new IdleState(_fabricTransitions.CreatTransitions(stateInfo.Transitions), _animator),
                
                _ => new UnknownState()
            };
        }
        public List<PlayerState> CreateStates(IEnumerable<PlayerStateInfo> stateInfos,
            PlayerStateMachine playerStateMachine)
        {
            return stateInfos.Select(stateInfo => CreateState(stateInfo, playerStateMachine)).ToList();
        }
        
    }
}
