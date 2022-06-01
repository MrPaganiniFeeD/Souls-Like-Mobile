using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IInputService : IUpdateableService
    {
        event Action LeftHandAttackButtonUp;
        event Action RightHandAttackButtonUp;
        event Action<Vector2> ChangeAxis;
        event Action RollButtonUp;

        Vector2 Axis { get; }

        bool IsLeftHandAttackButtonUp();
    }
}