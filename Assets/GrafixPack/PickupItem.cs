using UnityEngine;

namespace GrafixPack
{
    [RequireComponent(typeof(BoxCollider))]
    public class PickupItem : MonoBehaviour
    {
        private IInventory _inventory;
    
        public void Constructor(InventoryWithSlots inventoryWithSlots) => _inventory = inventoryWithSlots;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IItem itemPrefab))
            {
                if(_inventory.TryToAdd(itemPrefab.InventoryItem))
                    Destroy(other.gameObject);
            }
        }
    }
}
