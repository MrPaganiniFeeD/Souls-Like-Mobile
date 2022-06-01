using System;
using PlayerLogic.State;

namespace Enemy.State
{
    [Serializable]
    public class EnemySuperStateInfo : ISuperStateInfo
    {
        /*
        [SerializeField] private TypeEnemySuperState _typeSuperState;
        [SerializeField] private List<EnemyStateInfo> _childrenStateInfos;
        [SerializeField] private List<TypeEnemyTransition> _transitions;

        public Enum SuperState => _typeSuperState;
        public List<IStateInfo> ChildrenStateInfos => _childrenStateInfos.Cast<IStateInfo>().ToList();
        public List<Enum> Transitions => _transitions.Cast<Enum>().ToList();
    */
    }
}