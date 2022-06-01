using UnityEngine;
using Zenject;
public class InstallPrefabInHand : MonoBehaviour
{
    [SerializeField] private Transform _parentOverride;
    [SerializeField] private bool _isLeftHandSlot;
    [SerializeField] private bool _isRightHandSlot;
    
    [Inject] private DiContainer _diContainer;

    private GameObject _currentWeaponModel;
    
    public void UnLoadWeaponModel()
    {
        if (_currentWeaponModel != null)
            _currentWeaponModel.gameObject.SetActive(false);
    }
    public void DestroyWeapon()
    {
        if (_currentWeaponModel != null)
            Destroy(_currentWeaponModel);
    }
    public void LoadWeaponModel(GameObject weapon)
    {
        DestroyWeapon();

        if(weapon == null)
            return;
        
        //_diContainer.InstantiatePrefab(model);

        var model = _diContainer.InstantiatePrefab(weapon);
        model.transform.parent = _parentOverride;
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
        
        _currentWeaponModel = model;
    }
}

