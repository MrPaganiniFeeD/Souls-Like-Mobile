using System;
using System.Collections.Generic;
using System.Linq;
using Bot.Behaviour;
using Bot.State;
using DefaultNamespace;
using DefaultNamespace.Animation;
using DefaultNamespace.Hero.State;
using PlayerLogic.State;
using UnityEditor.Animations;
using UnityEngine;
using Zenject;

namespace Fabrics
{
    public class FabricEnemyState : IFabricState
    {
        /*
        private IFactoryTransition _fabricEnemyTransition;
        private IFollowBehaviour _followBehaviour;
        private IPatrolBehaviour _patrolBehaviour;
        private IObservableTransform _observableTransform;
        private IAttackBehaviour _attackBehaviour;
        private IAttackAnimation _attackAnimation;
        private Transform _transform;
        private ITakeDamageEnemyBehaviour _takeDamageEnemyBehaviour;
        private IDamageDetection _damageDetection;
        private IIdleBehaviour _idleBehaviour;  
        private IDeathBehaviour _deathBehaviour;
        private IEnemy _enemy;

        public FabricEnemyState(IObservableTransform observableTransform, GameObject gameObject,
            IFactoryTransition fabricTransition)
        {
            _idleBehaviour = gameObject.GetComponent<IIdleBehaviour>();
            _followBehaviour = gameObject.GetComponent<IFollowBehaviour>();
            _patrolBehaviour = gameObject.GetComponent<IPatrolBehaviour>();
            _attackBehaviour = gameObject.GetComponent<IAttackBehaviour>();
            _attackAnimation = gameObject.GetComponent<IAttackAnimation>();
            _damageDetection = gameObject.GetComponent<IDamageDetection>();
            _takeDamageEnemyBehaviour = gameObject.GetComponent<ITakeDamageEnemyBehaviour>();
            _deathBehaviour = gameObject.GetComponent<IDeathBehaviour>();
            _transform = gameObject.GetComponent<Transform>();
            _enemy = gameObject.GetComponent<IEnemy>();
            _observableTransform = observableTransform;
            _fabricEnemyTransition = fabricTransition;
        }
        public BaseState CreateState(IStateInfo stateInfo, PlayerStateMachine playerStateMachine)
        {
            return stateInfo.State switch
            {
                TypeEnemyState.Idle => new IdleEnemyState(
                    _idleBehaviour,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                
                TypeEnemyState.Follow => new FollowState(
                    _followBehaviour,
                    _observableTransform,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                
                TypeEnemyState.Patrol => new PatrolState(
                    _patrolBehaviour,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                
                TypeEnemyState.Attack => new AttackEnemyState(
                    _attackBehaviour,
                    _attackAnimation,
                    _observableTransform,
                    _transform,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine))
                ,
                TypeEnemyState.TakeDamage => new TakeDamageEnemyState(
                    _takeDamageEnemyBehaviour,
                    _damageDetection,
                    _enemy.Stats,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                
                TypeEnemyState.Death => new DeathEnemyState(
                    _deathBehaviour,
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, playerStateMachine)),
                    
                _ => new UnknownState()
            };
        }
        public SuperState CreateSuperState(ISuperStateInfo stateInfo, PlayerStateMachine basePlayerStateMachine)
        {
            return stateInfo.SuperState switch
            {
                TypeEnemySuperState.Default => new DefaultEnemySuperState(
                    CreateStates(stateInfo.ChildrenStateInfos, basePlayerStateMachine),
                    _fabricEnemyTransition.CreatTransitions(stateInfo.Transitions, basePlayerStateMachine),
                    basePlayerStateMachine),
                
                
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public List<BaseState> CreateStates(List<IStateInfo> stateInfos, PlayerStateMachine playerStateMachine)
        {
            return stateInfos.Select(stateInfo => CreateState(stateInfo, playerStateMachine)).ToList();
        }
        public List<SuperState> CreateSuperStates(List<ISuperStateInfo> stateInfos, PlayerStateMachine basePlayerStateMachine)
        {
            return stateInfos.Select(stateInfo => CreateSuperState(stateInfo, basePlayerStateMachine)).ToList();
        }
    */
    }
}