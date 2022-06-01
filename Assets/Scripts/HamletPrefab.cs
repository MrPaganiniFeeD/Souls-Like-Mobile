using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamletPrefab : MonoBehaviour, IItem
{
    [SerializeField] private EquippedInfo _itemInfo;

    public IInventoryItem InventoryItem { get; private set; }

    private void Start()
    { 
        InventoryItem = new HamletForPawns(_itemInfo);
    }
}
public class HamletForPawns : IEquippedItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public IEquippedItemInfo EquippedInfo { get; }
    public Type Type => GetType();

    public HamletForPawns(IEquippedItemInfo itemInfo)
    {
        Info = itemInfo;
        EquippedInfo = itemInfo;
        State = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonedItem = new HamletForPawns(EquippedInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }
}
