using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Animation;
using UnityEngine;

public interface IWeaponInfo : IEquippedItemInfo
{
     int StaminaCost { get; }
     int ManaCost { get; }
     bool TwoHand { get; }
     IAnimationInfo AnimationInfo { get; }
}
