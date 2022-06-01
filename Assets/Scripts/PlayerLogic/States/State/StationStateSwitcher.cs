using System.Collections;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using UnityEngine;

public class StationStateSwitcher : IStationStateSwicher
{
    public void SwitchState<T>() where T : BaseState
    {
        throw new System.NotImplementedException();
    }
}
