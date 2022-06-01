using DefaultNamespace.Inventory.Equipped;
using DefaultNamespace.Weapon;
using UnityEngine;

namespace PlayerLogic.Weapon
{
    public class WeaponPrefabInstaller : MonoBehaviour, IWeaponPrefabInstaller
    {
        [SerializeField] private InstallPrefabInHand _leftHand;
        [SerializeField] private InstallPrefabInHand _rightHand;
        private void Start()
        {
            WeaponSlotEventManager.EquipLeftHandWeapon += LoadWeaponOnLeftHand;
            WeaponSlotEventManager.UnequippedLeftHandWeapon += UnloadWeaponOnLeftHand;

            WeaponSlotEventManager.EquipRightHandWeapon += LoadWeaponOnRightHand;
            WeaponSlotEventManager.UnequippedRightHandWeapon += UnloadWeaponOnRightHand;
        }

        private void LoadWeaponOnLeftHand(IWeaponInfo weaponInfo)
        {
            if(CheckDualWeapon(weaponInfo))
                return;
            _leftHand.UnLoadWeaponModel();
            _leftHand.LoadWeaponModel(weaponInfo.Prefab);
        }
        private void LoadWeaponOnRightHand(IWeaponInfo weaponInfo)
        {
            if(CheckDualWeapon(weaponInfo))
                return;
            _rightHand.UnLoadWeaponModel();
            _rightHand.LoadWeaponModel(weaponInfo.Prefab);
        }
        private void UnloadWeaponOnLeftHand(IWeaponInfo weaponInfo)
        {
            _leftHand.UnLoadWeaponModel();
        }
        private void UnloadWeaponOnRightHand(IWeaponInfo weaponInfo)
        {
            _rightHand.UnLoadWeaponModel();
        }

        private bool CheckDualWeapon(IWeaponInfo weaponInfo)
        {
            if (weaponInfo is IDualWeaponInfo dualWeaponInfo)
            {
                _rightHand.UnLoadWeaponModel();
                _leftHand.UnLoadWeaponModel();
                _leftHand.LoadWeaponModel(dualWeaponInfo.LeftDualWeaponPrefab);
                _rightHand.LoadWeaponModel(dualWeaponInfo.RightDualWeaponPrefab);
                return true;
            }

            return false;
        }
        public void OnDisable()
        {
            WeaponSlotEventManager.EquipLeftHandWeapon -= LoadWeaponOnLeftHand;
            WeaponSlotEventManager.UnequippedLeftHandWeapon -= UnloadWeaponOnLeftHand;

            WeaponSlotEventManager.EquipRightHandWeapon -= LoadWeaponOnRightHand;
            WeaponSlotEventManager.UnequippedRightHandWeapon -= UnloadWeaponOnRightHand;
        }
    }

    public interface IWeaponPrefabInstaller
    {
    }
}