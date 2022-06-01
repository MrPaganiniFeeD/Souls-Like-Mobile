using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.Stats;
using UnityEngine;
using UnityEngine.Serialization;

public class RingOfPowerPrefab : MonoBehaviour, IItem
{
    [SerializeField] private EquippedInfo itemInfo;

    public IInventoryItem InventoryItem { get; private set;}

    private void Awake()
    {
        InventoryItem = new RingOfPower(itemInfo);
    }

}
public class RingOfPower : IEquippedItem
{
    public IInventoryItemInfo Info => EquippedInfo;
    public IInventoryItemState State { get; private set; }
    public IEquippedItemInfo EquippedInfo { get; }
    public ItemBuffStats BuffStats { get; }
    public Type Type => GetType();


    public RingOfPower(IEquippedItemInfo info)
    {
        EquippedInfo = info;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new RingOfPower(EquippedInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }

    public void Using(PlayerStats playerStats)
    {
        throw new NotImplementedException();
    }
}

