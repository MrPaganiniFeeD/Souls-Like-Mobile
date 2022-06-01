using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Inventory.Equipped;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class WeaponSlot : IInventorySlot, IEquippedSlot, IWeaponSlot, IDisposable
{
    public event Action<IEquippedItemInfo> EquippedItem;
    public event Action<IEquippedItemInfo> UnequippedItem;
    
    public event Action InstalledItem;
    public event Action UninstalledItem;

    public IInventoryItem Item => _weaponItem;
    public IWeaponItem Weapon => _weaponItem;

    public Type TypeItem { get; }
    public int Capacity { get; private set; }
    public bool IsFull { get; private set; }
    public bool IsEmpty => Item == null;
    public int Amount => IsEmpty ? 0 : Item.State.Amount;
    public EquippedItemType Type { get; }
    public EquippedItemType EquippedItemType { get; }

    private IWeaponItem _weaponItem;
    private IWeaponItem _unarmedItem;
    
    private bool _isCanEquipTwoHandWeapon = true;
    public WeaponSlot(EquippedItemType itemType, IWeaponItem unarmedItem)
    {
        Type = itemType;
        EquippedItemType = itemType;
        _unarmedItem = unarmedItem; 
        WeaponSlotEventManager.EquipTwoHandWeapon += SlotIsFull;
        WeaponSlotEventManager.EquipWeapon += OnEquipWeapon;
        WeaponSlotEventManager.UnequippedWeapon += OnUnequippedWeapon;
        WeaponSlotEventManager.UnequippedTwoHandWeapon += SlotIsNotFull;
        EquipUnarmed();
    }

    public bool TrySetItem(IInventoryItem inventoryItem)
    {
        if (IsEmpty == false) return false;
        if (IsFull) return false;


        if (inventoryItem is IWeaponItem item && TryEquippedWeapon(item))
        {
            _weaponItem = item;
            Capacity = _weaponItem.WeaponInfo.MaxItemsInInventorySlot;

            InstalledItem?.Invoke();
            InstalledItem?.Invoke();
            EquippedItem?.Invoke(item.WeaponInfo);
            WeaponSlotEventManager.SendEquipWeapon(item.WeaponInfo);
            WeaponSlotEventManager.SendEquippedDifferentHandWeapon(item.WeaponInfo, Type);

            return true;
        }
        
        return false;
    }

    private bool TryEquippedWeapon(IWeaponItem weaponItem)
    {
        if (weaponItem.WeaponInfo.Type == Type || weaponItem.WeaponInfo.Type == EquippedItemType.LeftRightHandWeapon)
        {
            if (weaponItem.WeaponInfo.TwoHand && _isCanEquipTwoHandWeapon == false)
                return false;
            return true;
        }
        return false;
    }
    public void Clear()
    {
        if (IsEmpty)
            return;
        
        _weaponItem.State.UnEquipped();
        _weaponItem.State.Amount = 0;
        UnequippedItem?.Invoke(_weaponItem.WeaponInfo);
        UninstalledItem?.Invoke();
        WeaponSlotEventManager.SendUnequippedWeapon(_weaponItem.WeaponInfo);
        WeaponSlotEventManager.SendUnequippedDifferentHandWeapon(_weaponItem.WeaponInfo, Type);
        _weaponItem = null;
    }

    private void OnUnequippedWeapon()
    {
        _isCanEquipTwoHandWeapon = true;
        EquipUnarmed();

    }
    private void OnEquipWeapon() => _isCanEquipTwoHandWeapon = false;
    private void SlotIsNotFull() => IsFull = false;
    private void SlotIsFull() => IsFull = true;

    private void EquipUnarmed()
    {
        if (TryEquippedWeapon(_unarmedItem) == false)
            return;
        WeaponSlotEventManager.SendEquippedDifferentHandWeapon(_unarmedItem.WeaponInfo, Type);
    }
    public void Dispose()
    {
        WeaponSlotEventManager.UnequippedTwoHandWeapon -= SlotIsNotFull;
        WeaponSlotEventManager.EquipWeapon -= OnEquipWeapon;
        WeaponSlotEventManager.UnequippedWeapon -= OnUnequippedWeapon;
        WeaponSlotEventManager.EquipTwoHandWeapon -= SlotIsFull;
    }
}
