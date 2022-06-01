using PlayerLogic.State.StateMachine;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;

namespace Enemy.Transition
{
    public class TakeDamageEnemyTransition : ITransition
    {
        /*
        public PlayerStateMachine PlayerStateMachine { get; }
        private IDamageDetection _damageDetection;
        
        public TakeDamageEnemyTransition(PlayerStateMachine playerStateMachine, IDamageDetection damageDetection)
        {
            PlayerStateMachine = playerStateMachine;
            _damageDetection = damageDetection;
        }
        public void Enter() => 
            _damageDetection.ReceivedDamage += OnReceivedDamage;
        public void Exit() => 
            _damageDetection.ReceivedDamage -= OnReceivedDamage;
        public void Update()
        {
            
        }

        private void OnReceivedDamage() => Transit();
        public void Transit() => PlayerStateMachine.SwitchStateThroughTheBlock(TypeEnemyState.TakeDamage);
    */
        public PlayerStateMachine PlayerStateMachine { get; }
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Transit()
        {
            throw new System.NotImplementedException();
        }
    }
}