using Infrastructure.Services;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;

namespace PlayerLogic.States.Transition
{
    public class AttackTransition : ITransition
    {
        public PlayerStateMachine PlayerStateMachine { get; }
        private readonly IInputService _inputService;

        public AttackTransition(PlayerStateMachine playerStateMachine, IInputService inputService)
        {
            PlayerStateMachine = playerStateMachine;
            _inputService = inputService;
        }

        public void Enter() => 
            _inputService.LeftHandAttackButtonUp += Transit;

        public void Update()
        {
        
        }

        public void Exit() => 
            _inputService.LeftHandAttackButtonUp -= Transit;

        public void Transit() => 
            PlayerStateMachine.Enter<AttackState>();

        private void OnClidked()
        {
            Transit();
        }

    }
}
