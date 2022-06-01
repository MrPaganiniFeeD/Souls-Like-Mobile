using System;

namespace PlayerLogic.Behaviour.Attack
{
    public interface IDamageColliderSwitcher
    {
        event Action OnOpenCollider; 
        event Action OnCloseCollider;
    }
}
