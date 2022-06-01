using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoySlot : IInventorySlot
{
    public event Action InstalledItem;
    public event Action UninstalledItem;

    public IInventoryItem Item { get; private set; }
    public Type TypeItem => Item.Type;
    public int Capacity { get; private set; }

    public bool IsFull => !IsEmpty && Amount == Capacity;
    public bool IsEmpty => Item == null;
    public int Amount => IsEmpty ? 0 : Item.State.Amount;
    
    public bool TrySetItem(IInventoryItem inventoryItem)
    {   
        if (IsEmpty == false)
            return false;

        Item = inventoryItem;
        Capacity = inventoryItem.Info.MaxItemsInInventorySlot;
        InstalledItem?.Invoke();
        return true;
    }

    public void Clear()
    {
        if (IsEmpty)
            return;

        Item.State.Amount = 0;
        Item = null;
        UninstalledItem?.Invoke();

    }

}
