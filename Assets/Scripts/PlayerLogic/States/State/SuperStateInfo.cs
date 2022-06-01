using System;
using System.Collections.Generic;
using System.Linq;
using PlayerLogic.State;
using UnityEngine;

namespace DefaultNamespace.Hero.State
{ 
    [Serializable]
    public class SuperStateInfo : ISuperStateInfo
    {
        /*
        [SerializeField] private TypePlayerSuperState _superState;
        [SerializeField] private List<PlayerStateInfo> _childrenStateInfos;
        [SerializeField] private List<TypeTransitions> _transitions;
        
        public Enum SuperState => _superState;
        public List<IStateInfo> ChildrenStateInfos => _childrenStateInfos.Cast<IStateInfo>().ToList();
        public List<Enum> Transitions => _transitions.Cast<Enum>().ToList();
    */
    }
}