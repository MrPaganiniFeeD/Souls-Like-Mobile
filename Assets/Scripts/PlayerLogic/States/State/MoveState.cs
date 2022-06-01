using System;
using UnityEngine;

namespace PlayerLogic.States.State
{
    public class MoveState : IMoveState
    {
        public int Duration { get; } = 0;
        private float _speed;


        public void Enter(IMoveStatePayloaded payloaded)
        {
            _speed = payloaded.Speed;
            Debug.Log("Player move state enter");            
        }

        public void Init() => 
            throw new NotImplementedException();

        public void Enter() => 
            throw new NotImplementedException();

        public void Update() => 
            throw new System.NotImplementedException();

        public void FixedUpdate() => 
            throw new NotImplementedException();

        public void Exit() => 
            Debug.Log("PlayerMoveState exit");
    }
}
