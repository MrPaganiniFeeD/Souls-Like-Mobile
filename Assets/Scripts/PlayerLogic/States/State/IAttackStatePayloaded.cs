using Inventory.Item.EquippedItem.Weapon.Attack;

namespace PlayerLogic.States.State
{
    public interface IAttackStatePayloaded : IPlayerStatePayloaded
    {
        bool IsLeftHand { get; }
        bool IsRightHand { get; }

        AttackData Attack { get; }
    }
}