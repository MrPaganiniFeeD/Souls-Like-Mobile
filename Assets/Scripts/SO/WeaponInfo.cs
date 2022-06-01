using System;
using System.Collections;
using System.Collections.Generic;
using Animation;
using DefaultNamespace.ModelData;
using UnityEngine;
using AnimationInfo = Animation.AnimationInfo;

[CreateAssetMenu(fileName = "New Item Info", menuName = "Items/Create New Weapon", order = 51)]

public class WeaponInfo : ItemInfo ,IWeaponInfo
{
    [SerializeField] private int _staminaCost;
    [SerializeField] private int _manaCost;
    [SerializeField] private bool _twoHand;

    [SerializeField] private EquippedItemType _equippedType;

    [SerializeField] private ItemBuffStats _buffStats;

    [Header("Animation Info")]
    [SerializeField] private AnimationInfo _animationInfo;
    [Header("Model Info")] 
    [SerializeField] private ModelInfo _modelInfo;

    
    public int StaminaCost => _staminaCost;
    public int ManaCost => _manaCost;

    public bool TwoHand => _twoHand;

    public IModelInfo ModelInfo => _modelInfo;
    public IAnimationInfo AnimationInfo => _animationInfo;
    public EquippedItemType Type => _equippedType;
    public ItemBuffStats ItemBuffStats => _buffStats;
}
