using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create New Items", order = 51)]
public class ItemInfo : ScriptableObject, IInventoryItemInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _discription;
    [Min(1)]
    [SerializeField] private int _maxItemsInInventorySlot;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _pefab;

    public string Id => _id;
    public string Name => _name;
    public string Discription => _discription;
    public int MaxItemsInInventorySlot => _maxItemsInInventorySlot;
    public Sprite Icon => _icon;
    public GameObject Prefab => _pefab;
}
