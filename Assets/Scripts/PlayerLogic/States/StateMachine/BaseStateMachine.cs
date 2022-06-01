using System;
using System.Collections.Generic;
using System.Linq;
using PlayerLogic.State;
using PlayerLogic.States.State;

namespace PlayerLogic.States.StateMachine
{
    public class BaseStateMachine
    {
        public bool IsBlockedSwitch { get; set; }
        private Dictionary<Enum, BaseState> _allStates;
        private BaseState _currentState;
        private IFabricState _fabricPlayerStates;


        public BaseStateMachine(IFabricState fabricState)
        {
            _fabricPlayerStates = fabricState;
        }

        public void InitStates()
        {
            _currentState = _allStates[TypeEnemyState.Attack];
            _currentState.Enter();
            IsBlockedSwitch = false;
        }

        public void SwitchState(Enum typeState)
        {
            if (IsBlockedSwitch)
                return;
            if (!_currentState.IsLooping &&
                Equals(_allStates.FirstOrDefault(x => x.Value == _currentState).Key, typeState))
                return;

            SetNewState(typeState);
        }

        public void Update() => 
            _currentState?.Update();

        public void ClearState()
        {
            _currentState.Exit();
            SetBlockedSwitch(false);
            _currentState = null;
        }
        private void SetNewState(Enum typeState)
        {
            BaseState newState = GetState(typeState);
            _currentState.Exit();
            SetBlockedSwitch(newState.IsBlockedState);
            newState.Enter();
            _currentState = newState;
        }
        private new void SetBlockedSwitch(bool flag) => 
            IsBlockedSwitch = flag;

        private BaseState GetState(Enum typeState) => 
            _allStates[typeState];
        
    }
}