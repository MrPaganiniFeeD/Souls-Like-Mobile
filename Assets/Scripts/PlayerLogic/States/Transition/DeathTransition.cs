using PlayerLogic.State.StateMachine;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;

namespace DefaultNamespace.Hero.Transition
{
    public class DeathTransition : ITransition
    {
        public PlayerStateMachine PlayerStateMachine { get; }

        private IDamageDetection _damageDetection;

        public DeathTransition(PlayerStateMachine playerStateMachine, IDamageDetection damageDetection)
        {
            PlayerStateMachine = playerStateMachine;
            _damageDetection = damageDetection;
        }
        
        public void Enter() => _damageDetection.TakingDamage += OnReceivedDamage;
        public void Exit() => _damageDetection.TakingDamage -= OnReceivedDamage;
        public void Update()
        {
            
        }

        private void OnReceivedDamage(int damage)
        {
            
        }
        public void Transit() => PlayerStateMachine.SwitchStateThroughTheBlock(TypePlayerState.TakeDamage);

    }
}