using System;
using Bot.Behaviour;
using PlayerLogic.Animation;
using UnityEngine;

namespace PlayerLogic.Behaviour.Death
{
    public class DeathPlayerBehaviour : MonoBehaviour, IDeathBehaviour
    {
        public event Action EndBehaviour;

        private PlayerStateAnimator _playerAnimator;

        private void Awake() => 
            _playerAnimator = GetComponent<PlayerStateAnimator>();

        public void Enter()
        {
        }

        public void Death() => 
            _playerAnimator.StartDeathAnimation();

        public void Exit()
        {
               
        }
    }
}