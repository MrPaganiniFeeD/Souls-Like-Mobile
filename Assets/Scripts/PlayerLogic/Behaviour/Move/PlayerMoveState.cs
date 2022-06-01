using System.Collections.Generic;
using Infrastructure.Services;
using PlayerLogic.Animation;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;
using PlayerState = PlayerLogic.States.State.PlayerState;

namespace PlayerLogic.Behaviour.Move
{
    public class PlayerMoveState : PlayerState, IMoveState, IRotateState
    {
        private readonly CharacterController _characterController;
        private readonly PlayerStateAnimator _playerAnimator;
        private readonly IInputService _inputService;
        private readonly Transform _transform;
        private readonly Camera _camera;

        public override float Duration { get; } = 0f;
        private float _speed = 3.65f;
        private float _rotateSpeed = 1f;


        public PlayerMoveState(List<ITransition> transitions, IInputService inputService,
            Camera camera, Transform transform, CharacterController characterController,
            PlayerStateAnimator playerAnimator) : base(transitions)
        {
            _inputService = inputService;
            _camera = camera;
            _transform = transform;
            _characterController = characterController;
            _playerAnimator = playerAnimator;
        }

        public void Enter(IMoveStatePayloaded payloaded)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _playerAnimator.StartMoveAnimation();
            Debug.Log("MoveState Enter");
        }

        public override void Update()
        {
            base.Update();
            Move();
        }

        public override void Exit()
        {
            base.Exit();            
            _playerAnimator.StopMoveAnimation();
        }

        private void Move()
        {
            Vector3 movementDirection = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementDirection = _camera.transform.TransformDirection(_inputService.Axis);
                movementDirection.y = 0f;
                Rotate(movementDirection);
                movementDirection.Normalize();
                _playerAnimator.UpdateVelocity(movementDirection.x, movementDirection.z);
            }

            _characterController.Move(_speed * movementDirection * Time.deltaTime);
        }
        
        public void Rotate(Vector3 direction) => 
            _transform.forward = direction;
    }
}
