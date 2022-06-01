using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagonSwordWeapon : MonoBehaviour, IItem
{
    [SerializeField] private WeaponInfo _weaponInfo;
    public IInventoryItem InventoryItem { get; private set; }


    private void Awake()
    {
        InventoryItem = new DagonSword(_weaponInfo);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForEndOfFrame();

    }
}
public class DagonSword : IWeaponItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public Type Type => GetType();
    public IWeaponInfo WeaponInfo { get; }
    public void Attack()
    {
           
    }
    public DagonSword(IWeaponInfo itemInfo)
    {
        Info = itemInfo;
        WeaponInfo = itemInfo;
        State = new InventoryItemState();
    }
    public IInventoryItem Clone()
    {
        var clonedItem = new DagonSword(WeaponInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }
}
