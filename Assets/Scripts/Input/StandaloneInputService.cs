using System;
using Infrastructure.Services;
using UnityEngine;

namespace DefaultNamespace.UI.Input
{
    public class StandaloneInputService : InputService
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
            if(IsRolloverButtonUp() || IsSpaceButtonUp())
                RollButtonUp?.Invoke();
            if(IsLeftHandAttackButtonUp() || IsLeftClickMouseButton())
                LeftHandAttackButtonUp?.Invoke();
            if(IsRightHandAttackButtonUp() || IsRightClickMouseButton())
                RightHandAttackButtonUp?.Invoke();
            
            Axis = GetSimpleInputAxis();
        }

        private bool IsSpaceButtonUp()
        {
            return SimpleInput.GetKey(KeyCode.Space);
        }

        private bool IsRightClickMouseButton() => 
            SimpleInput.GetKey(KeyCode.Mouse1);

        private bool IsLeftClickMouseButton() => 
            SimpleInput.GetKey(KeyCode.Mouse0);

        private static Vector2 GetSimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        private static Vector2 GetUnityAxis() =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}