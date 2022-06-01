using PlayerLogic.State.StateMachine;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;

namespace Enemy.Transition
{
    public class FollowTransition : ITransition
    {
        /*
        private IObservableTransform _target;
        private Transform _selfTransform;
        private float _foundDistance = 10;
        public PlayerStateMachine PlayerStateMachine { get; }
        
        public FollowTransition(PlayerStateMachine playerStateMachine, IObservableTransform target, Transform selfTransform)
        {
            PlayerStateMachine = playerStateMachine;
            _target = target;
            _selfTransform = selfTransform;
        }
        public void Enter()
        {
            _target.OnChangePosition += UpdateTargetPosition;
            UpdateTargetPosition(_target.GetTransform());
        }
        public void Exit() => 
            _target.OnChangePosition -= UpdateTargetPosition;

        public void Update()
        {
            
        }

        public void Transit() => 
            PlayerStateMachine.SwitchState(TypeEnemyState.Follow);

        private void UpdateTargetPosition(Transform targetTransform)
        {
            if(Vector3.Distance(targetTransform.position, _selfTransform.position) < _foundDistance)
                Transit();
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