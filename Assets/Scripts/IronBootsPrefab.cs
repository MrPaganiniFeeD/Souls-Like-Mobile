using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.Stats;
using UnityEngine;
using UnityEngine.Serialization;

public class IronBootsPrefab : MonoBehaviour, IItem
{
    [SerializeField] private EquippedInfo itemInfo;
    public IInventoryItem InventoryItem { get; private set; }

    private void Awake()
    {
        InventoryItem = new IronBoots(itemInfo);
    }

}
public class IronBoots : IInventoryItem, IEquippedItem
{
    public IInventoryItemInfo Info => EquippedInfo;
    public IInventoryItemState State { get;  }
    public IEquippedItemInfo EquippedInfo { get; }
    public ItemBuffStats BuffStats { get; }
    public Type Type => GetType();


    public IronBoots(IEquippedItemInfo info)
    {
        EquippedInfo = info;
        State = new InventoryItemState();
        BuffStats = info.ItemBuffStats;
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new IronBoots(EquippedInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }

    public void Using(PlayerStats playerStats)
    {
        throw new NotImplementedException();
    }
}
