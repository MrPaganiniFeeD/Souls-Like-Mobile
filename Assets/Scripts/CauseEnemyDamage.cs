using System;
using System.Collections;
using System.Collections.Generic;
using PlayerLogic.Behaviour.Attack;
using UnityEngine;

public class CauseEnemyDamage : MonoBehaviour, ICauseDamage
{
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private IDamageColliderSwitcher _colliderSwitcher;
    private IStats _enemyStats;
    private IEnemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<IEnemy>();
        _boxCollider = GetComponent<BoxCollider>(); 
        _rigidbody = GetComponent<Rigidbody>();
        _colliderSwitcher = GetComponentInParent<IDamageColliderSwitcher>();
    }

    private void Start()
    {
        _enemyStats = _enemy.Stats;
        _boxCollider.enabled = false;
        if (_colliderSwitcher != null)
        {
            _colliderSwitcher.OnOpenCollider += EnableCollider;
            _colliderSwitcher.OnCloseCollider += DisableCollider; 
        }
        else
        {
            Debug.Log("Collider Switcher not found");
        }
    }

    private void OnDisable()
    {
        if (_colliderSwitcher != null)
        {
            _colliderSwitcher.OnOpenCollider -= EnableCollider;
            _colliderSwitcher.OnCloseCollider -= DisableCollider;
        }
        else
        {
            Debug.Log("Collider Switcher not found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamageDetection damageableEnemy))
        {
            damageableEnemy.ApplyDamage(_rigidbody, _enemyStats.Damage.Value);
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
