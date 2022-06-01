using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightieArmorPrefab : MonoBehaviour, IItem
{
    [SerializeField] private EquippedInfo _itemInfo;

    public IInventoryItem InventoryItem { get; private set; }

    private void Start()
    { 
        InventoryItem = new NightieArmor(_itemInfo);
    }
}

public class NightieArmor : IEquippedItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public IEquippedItemInfo EquippedInfo { get; }
    public Type Type => GetType();

    public NightieArmor(IEquippedItemInfo itemInfo)
    {
        Info = itemInfo;
        EquippedInfo = itemInfo;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new NightieArmor(EquippedInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }
}