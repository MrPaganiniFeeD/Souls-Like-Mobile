using System;
using System.Collections.Generic;
using Bot.Behaviour;
using PlayerLogic.State;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Hero.State
{
    public class TakeDamageState : BaseState
    {
        public override event Action<Enum> EndState;
        
        private ITakeDamageBehaviour _takeDamageBehaviour;
        private IDamageDetection _damageDetection;
        private IStats _stats;

        public TakeDamageState(ITakeDamageBehaviour takeDamageBehaviour, IDamageDetection damageDetection,IStats stats, List<ITransition> transitions) : base(takeDamageBehaviour, transitions)
        {
            _takeDamageBehaviour = takeDamageBehaviour;
            _damageDetection = damageDetection;
            _stats = stats;
            IsBlockedState = true;
            IsLooping = true;
        }

        public override void Enter()
        {
            base.Enter();
            TypeNextState = TypePlayerState.Idle;
            _damageDetection.TakingDamage += OnTakingDamage;
            _damageDetection.TakingBodyDamage += OnTakingBodyDamage;
        }

        public override void Exit()
        {
            base.Exit();
            _damageDetection.TakingDamage -= OnTakingDamage;
            _damageDetection.TakingBodyDamage -= OnTakingBodyDamage;
        }

        private void OnTakingBodyDamage(Rigidbody attachedBody, int damage)
        {
            Debug.Log(damage);
            if (GetCountingHeath(damage) <= 0)
            {
                TypeNextState = TypePlayerState.Death;
                EndState?.Invoke(TypeNextState);
                return;
            }
            
            GetCountingHeath(damage);
            _takeDamageBehaviour.ApplyDamage(attachedBody, damage);   
        }

        private void OnTakingDamage(int damage)
        {
            _stats.Health.Value -= damage;
            _takeDamageBehaviour.ApplyDamage(damage);
        }

        private int GetCountingHeath(float damage)
        {
            
            if(_stats.Protection.Value > 80)
                damage *= 0.2f;
            else if (_stats.Protection.Value > 150)
                damage *= 0.3f;
            else if (_stats.Protection.Value > 250)
                damage *= 0.5f;
            else if(_stats.Protection.Value <= 80)
                damage *= 1 - _stats.Protection.Value / 100f;
            
            return _stats.Health.Value -= (int)damage;
        }

        protected override void OnEndBehaviour()
        {
            EndState?.Invoke(TypeNextState);
        }
    }
}