using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponSlot
{
    IWeaponItem Weapon { get; }

    EquippedItemType EquippedItemType { get; }
}
