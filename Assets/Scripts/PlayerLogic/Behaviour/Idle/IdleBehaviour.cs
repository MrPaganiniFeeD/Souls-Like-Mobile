using System;
using PlayerLogic.Animation;
using UnityEngine;

namespace PlayerLogic.Behaviour.Idle
{
    public class IdleBehaviour : MonoBehaviour, IIdleBehaviour
    {
        public event Action EndBehaviour;

        private PlayerStateAnimator _playerAnimator;

        private void Awake() => 
            _playerAnimator = GetComponent<PlayerStateAnimator>();

        public void Enter() => 
            _playerAnimator.StartIdleAnimation();

        public void Exit() => 
            _playerAnimator.StopIdleAnimation();

        public void Idling()
        {
        }
    }
}
