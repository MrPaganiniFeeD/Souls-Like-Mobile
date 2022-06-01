using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippedItem : IInventoryItem
{
    IEquippedItemInfo EquippedInfo { get; }
}
