using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using PlayerLogic.Behaviour.Attack;
using PlayerLogic.Stats;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

public class СauseDamage : MonoBehaviour, ICauseDamage
{
    [Inject] private PlayerStats _playerStats;
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private IDamageColliderSwitcher _colliderSwitcher;
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>(); 
        _rigidbody = GetComponent<Rigidbody>();
        _colliderSwitcher = GetComponentInParent<IDamageColliderSwitcher>();
        _boxCollider.enabled = false;
        
        if (_colliderSwitcher != null)
        {
            _colliderSwitcher.OnOpenCollider += EnableCollider;
            _colliderSwitcher.OnCloseCollider += DisableCollider; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamageDetection damageableEnemy))
        {
            damageableEnemy.ApplyDamage(_rigidbody, _playerStats.Damage.Value);
        }
    }
    private void OnDisable()
    {
        if (_colliderSwitcher != null)
        {
            _colliderSwitcher.OnOpenCollider -= EnableCollider;
            _colliderSwitcher.OnCloseCollider -= DisableCollider;
        }

    }

    private void EnableCollider()
    {
        _boxCollider.enabled = true;
    }

    private void DisableCollider()
    {
        _boxCollider.enabled = false;
    }
}
