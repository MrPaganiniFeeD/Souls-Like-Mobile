using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IInventorySlot
{ 
    event Action InstalledItem;
    event Action UninstalledItem;

    bool IsFull { get; }
    bool IsEmpty { get; }

    IInventoryItem Item { get; }
    Type TypeItem { get; }
    int Amount { get; }
    int Capacity { get; }

    bool TrySetItem(IInventoryItem inventoryItem);
    void Clear();
    
}
