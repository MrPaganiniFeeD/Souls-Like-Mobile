using System;
using System.Collections.Generic;
using DefaultNamespace.Inventory.Equipped;
using Fabrics;

namespace Inventory.InventoryWithSlots.Equipped
{
    public class InventoryEquipped : IInventory
    {
        public event Action StateChanged;
        public event Action<IInventoryItem, int> ItemAdded;
        public event Action<IInventoryItem, int> ItemRemoved;

        public IWeaponSlot LeftHand { get; private set; }
        public IWeaponSlot RightHand { get; private set; }


        public int Capactiy => Slots.Count;
        public ISlotSorter SlotSorter { get; }
        public List<IInventorySlot> Slots { get; }
        public bool IsFull => false;
    
        private readonly IFabricSlot _fabricSlot;
    
        public InventoryEquipped(IFabricSlot fabricSlot)
        {
            _fabricSlot = fabricSlot;
            Slots = new List<IInventorySlot>
            {
                _fabricSlot.CreateEquippedSlot(EquippedItemType.Hamlet),
                _fabricSlot.CreateEquippedSlot(EquippedItemType.WeaponLeftHand),
                _fabricSlot.CreateEquippedSlot(EquippedItemType.Armor),
                _fabricSlot.CreateEquippedSlot(EquippedItemType.WeaponRightHand),
                _fabricSlot.CreateEquippedSlot(EquippedItemType.Boots),
                _fabricSlot.CreateEquippedSlot(EquippedItemType.Ring),
            };
            SlotSorter = new SlotSorter(Slots);
        }
        public bool TryToAdd(IInventoryItem item)
        {
            IInventorySlot slotWithSameItemButNotEmpty = Slots
                .Find(slot => slot.IsEmpty == false && slot.IsFull == false && slot.TypeItem == item.Type);

            if (slotWithSameItemButNotEmpty != null)
                return TryToAddToSlot(slotWithSameItemButNotEmpty, item);

            IInventorySlot emptySlot = Slots.Find(slot => slot.IsEmpty && slot.TypeItem == item.Type);
            if (emptySlot != null)
                return TryToAddToSlot(emptySlot, item);

            return false;
        }


        public bool TryToAddToSlot(IInventorySlot slot, IInventoryItem item)
        {
            bool fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventorySlot;
            int amountToAdd = fits ? item.State.Amount : item.Info.MaxItemsInInventorySlot - slot.Amount;
            int amountLeft = item.State.Amount - amountToAdd;
            IInventoryItem clonedItem = item.Clone();

            clonedItem.State.Amount = amountToAdd;

            if (slot.IsEmpty)
                slot.TrySetItem(clonedItem);
            else
                slot.Item.State.Amount += amountToAdd;

            ItemAdded?.Invoke(item, amountToAdd);
            InventoryEventManager.SendStateChangedEvent();

            if (amountLeft <= 0)
                return true;


            item.State.Amount = amountLeft;

            return TryToAdd(item);
        }

        public void TransitFromSlotToSlot(IInventorySlot fromSlot, IInventorySlot toSlot)
        {

            if (fromSlot == toSlot)
                return;
        
            int slotCapacity = fromSlot.Capacity;
            bool fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
            int amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;

            if (toSlot.TrySetItem(fromSlot.Item))
            {
                fromSlot.Clear();
                InventoryEventManager.SendStateChangedEvent();
                toSlot.Item.State.Amount += amountToAdd;
            }

        }
        public void Remove(Type itemType, int amount = 1)
        {
            throw new NotImplementedException();
        }
    }
}
