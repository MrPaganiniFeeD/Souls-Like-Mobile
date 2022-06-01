using UnityEngine;

namespace DefaultNamespace.Weapon
{
    public interface IDualWeaponInfo
    {
        GameObject LeftDualWeaponPrefab { get; }
        GameObject RightDualWeaponPrefab { get; }
    }
}