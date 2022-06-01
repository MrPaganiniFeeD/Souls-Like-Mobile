using System.Collections.Generic;
using DefaultNamespace.Animation;
using Infrastructure.Services;
using PlayerLogic.States.Transition;
using PlayerLogic.Stats;

namespace PlayerLogic.States.State
{
    public class RightHandAttackState : ComboAttackState
    {
        public RightHandAttackState(IAttackBehaviour attackBehaviour,
            IAttackAnimation attackAnimation,
            IAttackButton attackButton,
            IInputService inputService,
            IWeaponSlot weaponSlot,
            PlayerStats playerStats,
            List<ITransition> transitions)
            : base(attackBehaviour, attackAnimation, attackButton, inputService, weaponSlot, playerStats, transitions)
        {
        }
        
        public override float Duration { get; }
    }
}