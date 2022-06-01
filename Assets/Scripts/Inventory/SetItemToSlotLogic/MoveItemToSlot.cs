using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveItemToSlot
{
    public bool TrySetItemInSlot(IInventoryItem item, IInventorySlot slot)
    {
        switch (item)
        {
            case IEquippedItem equippedItem when slot is IEquippedSlot equippedSlot:
            {
                if (equippedItem.EquippedInfo.Type == equippedSlot.Type)
                    return true;

                break;
            }
            default: return false;
        }
        
        return false;



    }
}
