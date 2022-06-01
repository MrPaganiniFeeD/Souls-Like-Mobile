using System;

namespace DefaultNamespace.Inventory.Equipped
{
    public class WeaponSlotEventManager
    {
        public static event Action EquipWeapon;
        public static event Action UnequippedWeapon;

        public static event Action<IWeaponInfo> EquipLeftHandWeapon;
        public static event Action<IWeaponInfo> EquipRightHandWeapon;

        public static event Action<IWeaponInfo> UnequippedLeftHandWeapon;
        public static event Action<IWeaponInfo> UnequippedRightHandWeapon;

        public static event Action EquipTwoHandWeapon;
        public static event Action UnequippedTwoHandWeapon;

        public static void SendEquippedDifferentHandWeapon(IWeaponInfo weaponInfo, EquippedItemType hand)
        {
            switch (hand)
            {
                case EquippedItemType.WeaponLeftHand :
                    EquipLeftHandWeapon?.Invoke(weaponInfo);
                    break;
                
                case EquippedItemType.WeaponRightHand : 
                    EquipRightHandWeapon?.Invoke(weaponInfo);
                    break;
            }
        }

        public static void SendUnequippedDifferentHandWeapon(IWeaponInfo weaponInfo, EquippedItemType hand)
        {
            switch (hand)
            {
                case EquippedItemType.WeaponLeftHand :
                    UnequippedLeftHandWeapon?.Invoke(weaponInfo);
                    break;
                
                case EquippedItemType.WeaponRightHand : 
                    UnequippedRightHandWeapon?.Invoke(weaponInfo);
                    break;
            }
        }

        public static void SendEquipWeapon(IWeaponInfo weaponInfo)
        {
            if(weaponInfo.TwoHand)
                EquipTwoHandWeapon?.Invoke();
            EquipWeapon?.Invoke();
        }

        public static void SendUnequippedWeapon(IWeaponInfo weaponInfo)
        {
            if (weaponInfo.TwoHand)
                UnequippedTwoHandWeapon?.Invoke();
            UnequippedWeapon?.Invoke();  
        }
    }
}