using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponItem : IInventoryItem
{
    IWeaponInfo WeaponInfo { get; }

    void Attack();
}
