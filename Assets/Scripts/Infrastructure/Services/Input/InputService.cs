using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string LeftHandAttack = "LeftHandAttack";
        private const string RightHandAttack = "RightHandAttack";
        private const string Rollover = "Rollover";

        public abstract event Action LeftHandAttackButtonUp;
        public abstract event Action RightHandAttackButtonUp;
        public abstract event Action<Vector2> ChangeAxis;
        public abstract event Action RollButtonUp;
        public abstract Vector2 Axis { get; protected set; }
        
        
        public bool IsLeftHandAttackButtonUp() => SimpleInput.GetButtonUp(LeftHandAttack);
        public bool IsRightHandAttackButtonUp() => SimpleInput.GetButtonUp(RightHandAttack);
        public bool IsRolloverButtonUp() => SimpleInput.GetButtonUp(Rollover);
        public abstract void Update();
    }
}