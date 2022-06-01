using Data;
using Fabrics;
using Inventory.InventoryWithSlots.Equipped;

namespace Infrastructure.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        public InventoryEquipped InventoryEquipped { get; }
        public InventoryWithSlots InventoryWithSlots { get; }

        public InventoryService(int capacity)
        {
            IFabricSlot fabricSlot = new FabricSlot();

            InventoryEquipped = new InventoryEquipped(fabricSlot);
            InventoryWithSlots = new InventoryWithSlots(capacity, fabricSlot);
        }

        public void LoadProgress(PlayerProgress playerProgress) => 
            throw new System.NotImplementedException();

        public void UpdateProgress(PlayerProgress playerProgress) => 
            throw new System.NotImplementedException();
    }
}