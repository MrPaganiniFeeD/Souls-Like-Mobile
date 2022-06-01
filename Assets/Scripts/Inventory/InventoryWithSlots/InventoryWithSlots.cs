using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DefaultNamespace.Inventory.Equipped;
using Fabrics;


public class InventoryWithSlots : IInventory
{
    public event Action<IInventoryItem, int> ItemAdded;
    public event Action<IInventoryItem, int> ItemRemoved;
    public event Action StateChanged;

    public int Capactiy { get; private set; }
    public ISlotSorter SlotSorter { get; private set; }
    public bool IsFull => Slots.All(_slots => _slots.IsFull);
    public List<IInventorySlot> Slots { get; private set; }
    private IFabricSlot _fabricSlot;

    public InventoryWithSlots(int capacity, IFabricSlot fabricSlot)
    {
        Capactiy = capacity;
        _fabricSlot = fabricSlot;

        Slots = new List<IInventorySlot>(capacity);

        for (int i = 0; i < capacity; i++)
            Slots.Add(_fabricSlot.CreateInventorySlot());

        SlotSorter = new SlotSorter(Slots);
    }

    public bool TryToAdd(IInventoryItem item)
    {
        IInventorySlot slotWithSameItemButNotEmpty = Slots.Find(slot =>
            slot.IsEmpty == false && slot.IsFull == false && slot.TypeItem == item.Type);

        if (slotWithSameItemButNotEmpty != null)
            return TryToAddToSlot(slotWithSameItemButNotEmpty, item);

        IInventorySlot emptySlot = Slots.Find(slot => slot.IsEmpty);

        if (emptySlot != null)
            return TryToAddToSlot(emptySlot, item);

        return false;
    }

    public void TransitFromSlotToSlot(IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot == toSlot)
            return;
        if (fromSlot.IsEmpty)
            return;
        if (toSlot.IsFull)
            return;
        if (toSlot.IsEmpty == false && fromSlot.TypeItem != toSlot.TypeItem)
            return;

        int slotCapacity = fromSlot.Capacity;
        bool fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
        int amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
        int amountLeft = fromSlot.Amount - amountToAdd;

        if (toSlot.IsEmpty)
        {
            toSlot.TrySetItem(fromSlot.Item);
            fromSlot.Clear();
            InventoryEventManager.SendStateChangedEvent();
        }


        toSlot.Item.State.Amount += amountToAdd;

        if (fits)
            fromSlot.Clear();
        else
            fromSlot.Item.State.Amount = amountLeft;

        InventoryEventManager.SendStateChangedEvent();
    }

    public void Remove(Type itemType, int amount = 1)
    {
        IInventorySlot[] slotsWithItem = SlotSorter.GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)
            return;

        int amountToRemove = amount;
        int count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.Amount >= amountToRemove)
            {
                slot.Item.State.Amount -= amountToRemove;

                if (slot.Amount <= 0)
                    slot.Clear();

                ItemRemoved?.Invoke(slot.Item, amountToRemove);
                InventoryEventManager.SendStateChangedEvent();

                break;
            }

            int amountRemoved = slot.Amount;
            amountToRemove -= slot.Amount;
            slot.Clear();
            ItemRemoved?.Invoke(slot.Item, amountRemoved);
            InventoryEventManager.SendStateChangedEvent();
        }
    }

    public bool TryToAddToSlot(IInventorySlot slot, IInventoryItem item)
    {
        if (slot == null)
            return false;

        bool fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventorySlot;
        int amountToAdd = fits ? item.State.Amount : item.Info.MaxItemsInInventorySlot - slot.Amount;
        int amountLeft = item.State.Amount - amountToAdd;
        IInventoryItem clonedItem = item.Clone();

        clonedItem.State.Amount = amountToAdd;

        if (slot.IsEmpty)
            slot.TrySetItem(clonedItem);
        else
            slot.Item.State.Amount += amountToAdd;


        ItemAdded?.Invoke(item, amountToAdd);
        InventoryEventManager.SendStateChangedEvent();

        if (amountLeft <= 0)
            return true;


        item.State.Amount = amountLeft;

        return TryToAdd(item);
    }
}
