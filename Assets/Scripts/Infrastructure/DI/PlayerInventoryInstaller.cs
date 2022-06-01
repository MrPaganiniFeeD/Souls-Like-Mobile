
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Inventory.Equipped;
using DefaultNamespace.SO;
using Fabrics;
using Inventory.InventoryWithSlots.Equipped;
using Inventory.Item.EquippedItem.Weapon.WeaponItem;
using UnityEngine;
using Zenject;

public class PlayerInventoryInstaller : MonoInstaller
{
    [SerializeField] private DualWeaponInfo _unarmedInfo;
    private FabricSlot _fabricSlot;
    private IWeaponSlotInstaller _weaponSlotInstller;
    public override void InstallBindings()
    {
        BindWeaponInstaller();
        BindInventoryEquipped();
        BindInventoryWithSlots();
    }

    private void BindWeaponInstaller()
    {
        /*
        _fabricSlot = new FabricSlot(new UnarmedWeapon(_unarmedInfo));
        Container.Bind<IWeaponSlotInstaller>().
            FromInstance(_fabricSlot).
            AsSingle();
    */
    }
    private void BindInventoryEquipped()
    {
        /*Container.Bind<InventoryEquipped>().
            FromNew().
            AsSingle().
            WithArguments
            (_fabricSlot);*/
    }

    private void BindInventoryWithSlots()
    {
    //    Container.Bind<InventoryWithSlots>().FromNew().AsSingle().WithArguments(25, _fabricSlot);
    }
}
