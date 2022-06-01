namespace Fabrics
{
    public interface IFabricSlot
    {
        IInventorySlot CreateInventorySlot();
        IInventorySlot CreateEquippedSlot(EquippedItemType equippedType);
    }
}