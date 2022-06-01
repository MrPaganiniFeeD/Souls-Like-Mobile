using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Services;
using PlayerLogic.Animation;
using PlayerLogic.States.StateMachine;
using PlayerLogic.States.Transition;
using UnityEngine;

namespace PlayerLogic.States.State
{
    public class PlayerMoveState : PlayerState, IMoveState
    {
        private readonly List<ITransition> _transition;
        private readonly IInputService _inputService;
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly CharacterController _characterController;
        private readonly PlayerStateAnimator _animator;

        public PlayerMoveState(List<ITransition> transition, IInputService inputService,
            Camera camera, Transform transform, CharacterController characterController, PlayerStateAnimator animator) 
            : base(transition)
        {
            _transition = transition;
            _inputService = inputService;
            _camera = camera;
            _transform = transform;
            _characterController = characterController;
            _animator = animator;
        }

        public override float Duration { get; }
        private float _speed = 3;

        
        public void Enter(IMoveStatePayloaded payloaded)
        {
            base.Enter();
            _speed = payloaded.Speed;
        }

        public override void Enter()
        {
            base.Enter();
            _animator.StartMoveAnimation();
        }

        public override void Update()
        {
            base.Update();
            Move(_inputService.Axis);
        }

        public override void Exit()
        {
            base.Enter();
            _animator.StopMoveAnimation();
        }

        private void Move(Vector2 direction)
        {
            Vector3 movementVector = Vector3.zero;
            if (direction.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(direction);
                movementVector.y = 0;
                movementVector.Normalize();

                _transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(_speed * movementVector * Time.deltaTime);
        }
    }
}