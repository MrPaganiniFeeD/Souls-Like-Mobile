using DefaultNamespace.Inventory;
using DefaultNamespace.Inventory.Equipped;
using Inventory.InventoryWithSlots.Equipped;

namespace Fabrics
{
    public class FabricSlot : IFabricSlot, IWeaponSlotInstaller
    {
        public IWeaponSlot LeftHandWeaponSlot => _leftHandSlot;
        public IWeaponSlot RightHandWeaponSlot => _rightHandSlot;
        
        private IWeaponItem _unarmed;

        private WeaponSlot _leftHandSlot;
        private WeaponSlot _rightHandSlot;

        public FabricSlot()
        {
            /*
            _unarmed = unarmed;
            _leftHandSlot = new WeaponSlot(EquippedItemType.WeaponLeftHand, _unarmed);
            _rightHandSlot = new WeaponSlot(EquippedItemType.WeaponRightHand, _unarmed);
        */
        }



        public IInventorySlot CreateInventorySlot()
        {
            return new InventoySlot();
        }
        public IInventorySlot CreateEquippedSlot(EquippedItemType equippedType)
        {
            return equippedType switch
            {
                EquippedItemType.Armor => new EquippedSlot(EquippedItemType.Armor),
                EquippedItemType.Boots => new EquippedSlot(EquippedItemType.Boots),
                EquippedItemType.Hamlet => new EquippedSlot(EquippedItemType.Hamlet),
                EquippedItemType.Ring => new EquippedSlot(EquippedItemType.Ring),
                EquippedItemType.WeaponLeftHand => _leftHandSlot,
                EquippedItemType.WeaponRightHand => _rightHandSlot,

                _ => new EquippedSlot(EquippedItemType.None)

            };
        }

    }
}