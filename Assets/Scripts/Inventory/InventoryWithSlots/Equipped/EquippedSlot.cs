using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class EquippedSlot : IInventorySlot, IEquippedSlot
{
    public event Action InstalledItem;
    public event Action UninstalledItem;

    public event Action<IEquippedItemInfo> EquippedItem;
    public event Action<IEquippedItemInfo> UnequippedItem;
    
    public IInventoryItem Item => _equippedItem;
    public Type TypeItem { get; }
    public int Capacity { get; private set; }
    public bool IsFull => !IsEmpty && Amount == Capacity;
    public bool IsEmpty => Item == null;
    public int Amount => IsEmpty ? 0 : _equippedItem.State.Amount;

    public EquippedItemType Type => _lockedType;

    private EquippedItemType _lockedType;
    private IEquippedItem _equippedItem;


    public EquippedSlot(EquippedItemType lockedType)
    {
        _lockedType = lockedType;
    }
    public bool TrySetItem(IInventoryItem inventoryItem)
    {
        if (IsEmpty == false) return false;
        
        if (inventoryItem is IEquippedItem item && item.EquippedInfo.Type == _lockedType)
        {
            _equippedItem = item;
            Debug.Log(_equippedItem.State.Amount);
            Debug.Log(Amount);
            InstalledItem?.Invoke();
            EquippedItem?.Invoke(item.EquippedInfo);
            Capacity = _equippedItem.Info.MaxItemsInInventorySlot;
            return true;
        }
        return false;
    }

    public void Clear()
    {
        if (IsEmpty)
            return;

        _equippedItem.State.UnEquipped();
        _equippedItem.State.Amount = 0;
        
        UninstalledItem?.Invoke();
        UnequippedItem?.Invoke(_equippedItem.EquippedInfo);
        _equippedItem = null;
    }
}
