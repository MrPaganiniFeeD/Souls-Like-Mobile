using System;
using Bot.Behaviour;
using PlayerLogic.Animation;
using UnityEngine;

public class TakeDamagePlayerBehaviour : MonoBehaviour, ITakeDamageBehaviour
{
    public event Action EndBehaviour;
    
    private Rigidbody _rigidbody;
    private Transform _transform;
    private PlayerStateAnimator _playerAnimator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _playerAnimator = GetComponent<PlayerStateAnimator>();
    }

    public void Enter()
    {
        
    }

    public void Exit() => 
        _playerAnimator.StopApplyDamageAnimation();

    public void ApplyDamage(Rigidbody attachedBody, int damage) => 
        _playerAnimator.StartApplyDamageAnimation();

    public void ApplyDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
