using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSpear : MonoBehaviour, IItem
{
    [SerializeField] private WeaponInfo _weaponInfo;
    public IInventoryItem InventoryItem { get; private set; }


    private void Awake()
    {
        InventoryItem = new Spear(_weaponInfo);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForEndOfFrame();

    }
}

[Serializable]
public class Spear : IWeaponItem
{
    public IInventoryItemInfo Info => WeaponInfo;
    public ItemBuffStats BuffStats { get; }
    public IInventoryItemState State { get; private set; }
    public Type Type => GetType();

    public IWeaponInfo WeaponInfo { get; }
    public void Attack()
    {
        Debug.Log("Spear attack");
    }

    public Spear(IWeaponInfo itemInfo)
    {
        WeaponInfo = itemInfo;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedItem = new Spear(WeaponInfo);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }
}

