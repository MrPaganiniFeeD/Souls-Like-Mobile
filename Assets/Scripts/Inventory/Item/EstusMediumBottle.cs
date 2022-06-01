using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.Stats;
using UnityEngine;
using UnityEngine.Serialization;

public class EstusMediumBottle : MonoBehaviour, IItem
{
    [SerializeField] private ItemInfo itemInfo;
    public IInventoryItem InventoryItem { get; private set; }
    private void Awake()
    {
        InventoryItem = new Estus(itemInfo);
    }

}
[Serializable]

public class Estus : IInventoryItem
{
    public IInventoryItemInfo Info { get; private set; }
    public ItemBuffStats BuffStats { get; }
    public IInventoryItemState State { get; private set; }
    public Type Type => GetType();
    
    public Estus(IInventoryItemInfo itemInfo)
    {
        Info = itemInfo;
        State = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonedItem = new Estus(Info);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }

    public void Using(PlayerStats playerStats)
    {
        throw new NotImplementedException();
    }
}
