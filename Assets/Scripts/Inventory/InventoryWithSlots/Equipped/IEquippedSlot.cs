
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippedSlot
{
    public event Action<IEquippedItemInfo> EquippedItem;
    public event Action<IEquippedItemInfo> UnequippedItem;

    EquippedItemType Type { get; }

}
