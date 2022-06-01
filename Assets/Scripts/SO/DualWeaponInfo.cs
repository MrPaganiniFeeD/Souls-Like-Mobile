using Animation;
using DefaultNamespace.ModelData;
using DefaultNamespace.Weapon;
using UnityEngine;
using AnimationInfo = Animation.AnimationInfo;

namespace DefaultNamespace.SO
{
    [CreateAssetMenu(fileName = "New Item Info", menuName = "Items/Create New Dual Weapon", order = 51)]
    public class DualWeaponInfo : ItemInfo, IWeaponInfo, IDualWeaponInfo
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

        [Header("Prefab Info")] 
        [SerializeField] private GameObject _leftWeaponPrefab;
        [SerializeField] private GameObject _rightWeaponPrefab;

        public int StaminaCost => _staminaCost;
        public int ManaCost => _manaCost;
        public bool TwoHand => _twoHand;
        public IModelInfo ModelInfo => _modelInfo;
        public IAnimationInfo AnimationInfo => _animationInfo;
        public EquippedItemType Type => _equippedType;
        public ItemBuffStats ItemBuffStats => _buffStats;
        public GameObject LeftDualWeaponPrefab => _leftWeaponPrefab;
        public GameObject RightDualWeaponPrefab => _rightWeaponPrefab;
    }
}