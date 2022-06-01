using System;
using System.Collections.Generic;

public interface IInventory
{
    int Capactiy { get; }
    bool IsFull { get; }
    List<IInventorySlot> Slots {get;}
    ISlotSorter SlotSorter { get;}

    event Action StateChanged;
    event Action<IInventoryItem, int> ItemAdded;
    event Action<IInventoryItem, int> ItemRemoved;



    bool TryToAdd(IInventoryItem item);
    bool TryToAddToSlot(IInventorySlot slotWithSameItemButNotEmpty, IInventoryItem item);
    void TransitFromSlotToSlot(IInventorySlot otherSlot, IInventorySlot slot);
    void Remove(Type itemType, int amount = 1);
}
