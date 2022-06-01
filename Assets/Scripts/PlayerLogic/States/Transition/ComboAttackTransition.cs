using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DefaultNamespace.Stats;
using PlayerLogic.State.StateMachine;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;

public class ComboAttackTransition : ITransition
{
    public PlayerStateMachine PlayerStateMachine { get; }

    private IAttackButton _leftHandAttackButton;
    private IAttackButton _rightHandAttackButton;
    private IWeaponInfo _leftWeapon;
    private IWeaponInfo _rightWeapon;
    private PlayerStats _playerStats;

    public ComboAttackTransition(PlayerStateMachine playerStateMachine,
        IAttackButton leftHandAttackButton,
        IAttackButton rightHandAttackButton,
        PlayerStats playerStats)
    {
        PlayerStateMachine = playerStateMachine;
        _leftHandAttackButton = leftHandAttackButton;
        _rightHandAttackButton = rightHandAttackButton;
        _playerStats = playerStats;
    }
    public void Enter()
    {
        _leftHandAttackButton.Clicked += OnClickedLeftButton;
        _rightHandAttackButton.Clicked += OnClickedRightButton;
    }
    public void Exit()
    {
        _leftHandAttackButton.Clicked -= OnClickedLeftButton;
        _rightHandAttackButton.Clicked -= OnClickedRightButton;
    }

    public void Update()
    {
        
    }

    private void OnClickedLeftButton()
    {
        if (_leftWeapon == null)
            return;
        TransitTo(TypePlayerState.AttackLeftHand, _leftWeapon);
    }

    private void OnClickedRightButton()
    {
        if(_rightWeapon == null)
            return;
        TransitTo(TypePlayerState.AttackRightHand, _rightWeapon);
    }
    public void Transit()
    {
        
    }

    private void TransitTo(TypePlayerState typeState, IWeaponInfo weaponInfo)
    {
        if(_playerStats.Stamina.CheckValue(weaponInfo.StaminaCost) &&
           _playerStats.Mana.CheckValue(weaponInfo.ManaCost))
            PlayerStateMachine.SwitchState(typeState);
    }
    public void SetLeftHandWeapon(IWeaponInfo weaponInfo)
    {
        _leftWeapon = weaponInfo;
    }
    public void SetRightHandWeapon(IWeaponInfo weaponInfo)
    {
        _rightWeapon = weaponInfo;
    }
    public void ClearLeftHandWeapon(IWeaponInfo weaponInfo)
    {
        _leftWeapon = null;
    }
    public void ClearRightHandWeapon(IWeaponInfo weaponInfo)
    {
        _rightWeapon = null;
    }
}
