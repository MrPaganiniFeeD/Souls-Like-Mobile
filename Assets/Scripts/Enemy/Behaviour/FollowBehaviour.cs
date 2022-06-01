using System;
using System.Collections;
using System.Collections.Generic;
using Bot.Transition;
using Enemy.Animation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowBehaviour : MonoBehaviour, IFollowBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _stoppingDistance;

    public event Action EndBehaviour;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int FollowToTarget = Animator.StringToHash("Follow");

    private NavMeshAgent _navMeshAgent;
    private EnemyStateAnimator _stateAnimator;

    private float _lastSpeed;
    private int _lastStoppingDistance;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _stateAnimator = GetComponent<EnemyStateAnimator>();
    }

    public void Enter()
    {
        _lastStoppingDistance = (int) _navMeshAgent.stoppingDistance;
        _lastSpeed = _navMeshAgent.speed;
        
        _navMeshAgent.stoppingDistance = _stoppingDistance;     
        _navMeshAgent.speed = _speed;
        
        _stateAnimator.StartFollowAnimation(_speed);
    }
    public void Exit()
    {
        _navMeshAgent.stoppingDistance = _lastStoppingDistance;
        _navMeshAgent.speed = _lastSpeed;
        
        _stateAnimator.StopFollowAnimation();
    }

    public void Follow(Transform target) => _navMeshAgent.SetDestination(target.position);
}