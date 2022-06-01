using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.Stats;
using UnityEngine;
using UnityEngine.Serialization;

public class ApplePrefabs : MonoBehaviour, IItem
{
    [SerializeField] private ItemInfo appleInfo;
    public IInventoryItem InventoryItem { get; private set; }
    private void Awake()
    {
        InventoryItem = new Apple(appleInfo);
    }

}
[Serializable]

public class Apple : IInventoryItem
{
    public IInventoryItemInfo Info { get; private set; }
    public IInventoryItemState State { get; private set; }
    public Type Type => GetType();

    public Apple(IInventoryItemInfo itemInfo)
    {
        Info = itemInfo;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new Apple(Info);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }

    public void Using(PlayerStats playerStats)
    {
        throw new NotImplementedException();
    }
}

