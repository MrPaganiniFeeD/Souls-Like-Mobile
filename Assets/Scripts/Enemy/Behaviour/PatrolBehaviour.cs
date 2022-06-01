using System;
using Enemy.Animation;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Behaviour
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PatrolBehaviour : MonoBehaviour, IPatrolBehaviour
    {
        [SerializeField] private WayPoint[] _wayPoints;
        [SerializeField] private float _speed;
        [SerializeField] private int _stoppingDistance;
    
    
        public event Action EndBehaviour;
    
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Transform _selfTransform;
        private int _wayPointIndex;
        private Vector3 _target;
        private int _lastStoppingDistance; 
    
        private EnemyStateAnimator _stateAnimator;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _selfTransform = GetComponent<Transform>();
            _stateAnimator = GetComponent<EnemyStateAnimator>();
        }

        public void Patrol()
        {
            if(Vector3.Distance(_selfTransform.position, _target) < 0.5f)
            {
                InternalWayPointIndex();
                MoveToPoint();
            }
        }

        public void Enter()
        {
            _wayPointIndex = 0;
        
            MoveToPoint();
            _navMeshAgent.speed = _speed;

            _lastStoppingDistance = (int) _navMeshAgent.stoppingDistance;
            _navMeshAgent.stoppingDistance = _stoppingDistance;
        
            _stateAnimator.StartPatrolAnimation(_speed);
        }
        public void Exit()
        {
            _navMeshAgent.stoppingDistance = _lastStoppingDistance;
            _stateAnimator.StopPatrolAnimation();
        }

        private void MoveToPoint()
        {
            _target = _wayPoints[_wayPointIndex].transform.position;
            _navMeshAgent.SetDestination(_target);
        }
        private void InternalWayPointIndex()
        {
            _wayPointIndex++;
            if (_wayPointIndex == _wayPoints.Length)
                _wayPointIndex = 0;
        }
    }
}