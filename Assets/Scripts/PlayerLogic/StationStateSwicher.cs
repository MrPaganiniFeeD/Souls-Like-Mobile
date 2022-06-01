using System.Collections;
using System.Collections.Generic;
using PlayerLogic.State;
using PlayerLogic.States.State;
using UnityEngine;

public class StationStateSwicher
{
    private List<BaseState> _allStates;

    public StationStateSwicher(List<BaseState> allStates)
    {
        _allStates = allStates;
    }

}
