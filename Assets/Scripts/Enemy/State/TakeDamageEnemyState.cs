using System;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Bot.Stats;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;
using UnityEngine.Events;

namespace Bot.State
{
    public class TakeDamageEnemyState : BaseState
    {
        public override event Action<Enum> EndState;

        private ITakeDamageEnemyBehaviour _takeDamageEnemyBehaviour;
        private IDamageDetection _damageDetection;
        private IStats _enemyStats;
        private TypeEnemyState _nextState = TypeEnemyState.Follow;
        public TakeDamageEnemyState(ITakeDamageEnemyBehaviour takeDamageEnemyBehaviour, IDamageDetection damageDetection,
            IStats enemyStats, List<ITransition> transitions)
            : base(takeDamageEnemyBehaviour, transitions)
        {
            _takeDamageEnemyBehaviour = takeDamageEnemyBehaviour;
            _damageDetection = damageDetection;
            _enemyStats = enemyStats;
            IsLooping = true;
            IsBlockedState = true;
            TypeNextState = _nextState;
        }
        public override void Enter()
        {
            base.Enter();
            _damageDetection.TakingBodyDamage += OnTakingBodyDamage;
            _damageDetection.TakingDamage += OnTakingDamage;
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            base.Exit();
            _damageDetection.TakingBodyDamage -= OnTakingBodyDamage;
            _damageDetection.TakingDamage -= OnTakingDamage;
        }

        private void OnTakingDamage(int damage)
        {
            _takeDamageEnemyBehaviour.ApplyDamage(damage);
            _enemyStats.Health.Value -= damage;

        }

        private void OnTakingBodyDamage(Rigidbody attachedBody, int damage)
        {
            if (damage >= _enemyStats.Health.Value)
            {
                _nextState = TypeEnemyState.Death;
                EndState?.Invoke(_nextState);
                return;
            }
            
            _enemyStats.Health.Value -= damage;
            _takeDamageEnemyBehaviour.ApplyDamage(attachedBody, damage);
        }

        protected override void OnEndBehaviour()
        {
            EndState?.Invoke(_nextState);
        }
    }
}