using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlotSorter : ISlotSorter
{
    private List<IInventorySlot> _slots;

    public SlotSorter(List<IInventorySlot> slots)
    {
        _slots = slots;
    }


    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.TypeItem == itemType).Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (slot.IsEmpty == false)
                allItems.Add(slot.Item);
        }
        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => slot.IsEmpty == false && slot.TypeItem == itemType);

        foreach (var slot in slotsOfType)
            allItemsOfType.Add(slot.Item);

        return allItemsOfType.ToArray();
    }
    public IInventoryItem[] GetEqiuppedItems()
    {
        var requiredSlots = _slots.FindAll(slot => slot.IsEmpty == false && slot.Item.State.IsEquipped);
        var equippedItems = new List<IInventoryItem>();

        foreach (var slot in _slots)
            equippedItems.Add(slot.Item);

        return equippedItems.ToArray();
    }
    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }
    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => slot.IsEmpty == false && slot.TypeItem == itemType).ToArray();
    }
    public IInventorySlot GetSlot(Type itemType)
    {
        return _slots.FindAll(slot => slot.IsEmpty == false && slot.TypeItem == itemType).First();
    }
    public IInventorySlot GetEmptySlot(Type itemType)
    {
        return _slots.FindAll(slot => slot.IsEmpty && slot.TypeItem == itemType).First();
    }
    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }
    public int GetItemAmount(Type itemType)
    {
        int amount = 0;
        var allItemSlots = _slots.FindAll(slot => slot.IsEmpty == false && slot.TypeItem == itemType);

        foreach (var itemSlot in allItemSlots)
            amount += itemSlot.Amount;

        return amount;

    }

}
