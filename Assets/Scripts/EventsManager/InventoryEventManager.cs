using System;
using UnityEngine.Events;

namespace DefaultNamespace.Inventory.Equipped
{
    public class InventoryEventManager
    {
        public static event Action StateChanged;
        public static void SendStateChangedEvent()  => StateChanged?.Invoke();
    }
}