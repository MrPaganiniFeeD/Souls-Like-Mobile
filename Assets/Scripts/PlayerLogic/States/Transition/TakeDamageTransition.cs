using PlayerLogic.State.StateMachine;
using PlayerLogic.States.State;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;

namespace DefaultNamespace.Hero.Transition
{
    public class TakeDamageTransition : ITransition
    {
        public PlayerStateMachine PlayerStateMachine { get; }

        private IDamageDetection _damageDetection;

        public TakeDamageTransition(PlayerStateMachine playerStateMachine, IDamageDetection damageDetection)
        {
            PlayerStateMachine = playerStateMachine;
            _damageDetection = damageDetection;
        }
        
        public void Enter() => _damageDetection.ReceivedDamage += OnReceivedDamage;
        public void Exit() => _damageDetection.ReceivedDamage -= OnReceivedDamage;
        public void Update()
        {
            
        }

        private void OnReceivedDamage() => Transit();
        public void Transit() => PlayerStateMachine.SwitchStateThroughTheBlock(TypePlayerState.TakeDamage);
    }
}