using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class КatanaOrdinary : MonoBehaviour, IItem
{
    [SerializeField] private WeaponInfo _weaponInfo;
    public IInventoryItem InventoryItem { get; private set; }


    private void Awake()
    {
        InventoryItem = new Katana(_weaponInfo);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForEndOfFrame();

    }
}
 
[Serializable]
public class Katana : IWeaponItem
{
    public IInventoryItemInfo Info { get; private set; }
    public IWeaponInfo WeaponInfo { get; }

    public IInventoryItemState State { get; private set; }

    public Type Type => GetType();

    public void Attack()
    {
    }
    public Katana(IWeaponInfo itemInfo)
    {
        Info = itemInfo;
        WeaponInfo = itemInfo;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new Katana(WeaponInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }
}
