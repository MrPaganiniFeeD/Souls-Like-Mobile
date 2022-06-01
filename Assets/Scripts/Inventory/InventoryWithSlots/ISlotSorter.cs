using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISlotSorter
{
    IInventoryItem GetItem(Type type);
    
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItems(Type type);
    IInventoryItem[] GetEqiuppedItems();

    IInventorySlot[] GetAllSlots();
    IInventorySlot[] GetAllSlots(Type itemType);
    IInventorySlot GetSlot(Type type);
    IInventorySlot GetEmptySlot(Type type);

    bool HasItem(Type type, out IInventoryItem item);

    int GetItemAmount(Type itemType);
}
