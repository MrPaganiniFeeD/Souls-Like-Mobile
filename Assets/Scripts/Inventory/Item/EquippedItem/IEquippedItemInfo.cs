using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ModelData;
using UnityEngine;

public interface IEquippedItemInfo : IInventoryItemInfo
{
    IModelInfo ModelInfo { get; }
    EquippedItemType Type { get;}
    ItemBuffStats ItemBuffStats { get; }
}
