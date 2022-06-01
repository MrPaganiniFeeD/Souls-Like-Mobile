using System;
using Infrastructure.Services;
using UnityEngine;

namespace DefaultNamespace.UI.Input
{
    public class MobileInputService : InputService
    {
        public override event Action LeftHandAttackButtonUp;
        public override event Action RightHandAttackButtonUp;
        public override event Action<Vector2> ChangeAxis;
        public override event Action RollButtonUp;

        private Vector2 _currentAxis;

        public override Vector2 Axis
        {
            get => _currentAxis;
            protected set
            {
                if (_currentAxis == value) return;

                ChangeAxis?.Invoke(value);
                _currentAxis = value;
            }
        }

        public override void Update()
        {
            if(IsRolloverButtonUp())
                RollButtonUp?.Invoke();
            
            if(IsLeftHandAttackButtonUp())
                LeftHandAttackButtonUp?.Invoke();
            if(IsRightHandAttackButtonUp())
                RightHandAttackButtonUp?.Invoke();
            
            Axis = GetSimpleInputAxis();
        }

        private static Vector2 GetSimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}