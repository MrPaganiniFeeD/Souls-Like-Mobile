using System;
using Enemy.Animation;
using UnityEngine;

namespace Bot.Behaviour
{
    public class DeathEnemyBehaviour : MonoBehaviour, IDeathBehaviour
    {
        public event Action EndBehaviour;
        private EnemyStateAnimator _stateAnimator;

        private void Awake() => 
            _stateAnimator = GetComponent<EnemyStateAnimator>();

        public void Enter()
        {
            
        }

        public void Exit() =>
            _stateAnimator.StopDieAnimation();

        public void Death() => 
            _stateAnimator.StartDieAnimation();
    }
}