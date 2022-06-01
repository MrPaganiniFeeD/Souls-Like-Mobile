using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;

namespace PlayerLogic.Transition
{
    public class RollingTransition : ITransition
    {
        public PlayerStateMachine PlayerStateMachine => _playerStateMachine;

        private PlayerStateMachine _playerStateMachine;
        private PlayerStats _playerStats;

        public RollingTransition(PlayerStateMachine playerStateMachine, RollButton rollButton,
            PlayerStats playerStats)
        {
            _playerStateMachine = playerStateMachine;
            _playerStats = playerStats;
        }
    
        public void Enter()
        {
        }

        private void OnClicked()
        {
            Transit();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        
        }

        public void Transit()
        {
        }
    }
}
