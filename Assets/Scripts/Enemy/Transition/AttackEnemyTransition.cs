using PlayerLogic.State.StateMachine;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;

namespace Enemy.Transition
{
    public class AttackEnemyTransition : ITransition
    {
        /*
        public PlayerStateMachine PlayerStateMachine { get; }
        
        private IObservableTransform _targetObservableTransform;
        private IObservableTransform _selfObservableTransform;
        private IAttackBehaviour _attackBehaviour;

        public AttackEnemyTransition(PlayerStateMachine playerStateMachine,IObservableTransform targetObservableTransform, IObservableTransform selfObservableTransform, 
            IAttackBehaviour attackBehaviour)
        {
            PlayerStateMachine = playerStateMachine;
            _targetObservableTransform = targetObservableTransform;
            _attackBehaviour = attackBehaviour;
            _selfObservableTransform = selfObservableTransform;
        }
        public void Enter()
        {
            _selfObservableTransform.OnChangePosition += CheckAttackDistance;
            CheckAttackDistance(_selfObservableTransform.GetTransform());
        }
        public void Exit()
        {
            _selfObservableTransform.OnChangePosition -= CheckAttackDistance;
        }

        public void Update()
        {
            
        }

        private void CheckAttackDistance(Transform selfTransform)
        {
            if(Vector3.Distance(selfTransform.position,_targetObservableTransform.GetTransform().position) <= _attackBehaviour.Distance)
                Transit();
        }
        public void Transit()
        {
            PlayerStateMachine.SwitchState(TypeEnemyState.Attack);
        }
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