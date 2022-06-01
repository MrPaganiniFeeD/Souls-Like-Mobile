namespace Inventory.InventoryWithSlots.Equipped
{
    public interface IWeaponSlotInstaller
    {
        IWeaponSlot LeftHandWeaponSlot { get; }
        IWeaponSlot RightHandWeaponSlot { get; }
    }
}