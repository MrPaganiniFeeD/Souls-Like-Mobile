using System;
using UnityEngine;

namespace Inventory.Item.EquippedItem.Weapon.WeaponItem
{
    public class UnarmedWeapon : IWeaponItem
    {
        public IInventoryItemInfo Info => WeaponInfo;
        public IWeaponInfo WeaponInfo { get; }
        public IInventoryItemState State { get; }
        public Type Type => GetType();

        public UnarmedWeapon(IWeaponInfo itemInfo)
        {
            WeaponInfo = itemInfo;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedItem = new UnarmedWeapon(WeaponInfo);
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }

        public void Attack()
        {
            Debug.Log("Unarmed attack");
        }
    }
}