using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;
using PlayerLogic.Transition;

namespace Fabrics
{
    public class FactoryTransitions : IFactoryTransition
    {
        private IInputService _inputService;
        private readonly PlayerStateMachine _playerStateMachine;
    
        private IDamageDetection _damageDetection;
        private PlayerStats _playerStats;

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
                
                case TypeTransitions.Attack :
                    return new AttackTransition(_playerStateMachine, _inputService);
            }
            return new UnknownTransition();
        }
    
        public List<ITransition> CreatTransitions(IEnumerable<TypeTransitions> typeTransitions) => 
            typeTransitions.Select(CreateTransition).ToList();

    }
}

