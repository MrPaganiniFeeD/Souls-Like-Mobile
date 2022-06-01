using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItemInfo 
{
    string Id { get; }
    string Name { get; }
    string Discription { get; }
    int MaxItemsInInventorySlot { get; }
    Sprite Icon { get; }
    GameObject Prefab { get; }
}
public enum EquippedItemType
{
    None,
    WeaponLeftHand,
    WeaponRightHand,
    Boots,
    Armor,
    Hamlet,
    Ring,
    LeftRightHandWeapon,
}
