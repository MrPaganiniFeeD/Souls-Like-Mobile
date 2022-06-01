using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using PlayerLogic.Animation;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class RollingBehaviour : MonoBehaviour, IRolling
{
    public event Action EndBehaviour;

    [SerializeField] private AnimationCurve _curve;

    private float _speed;
    private float _currentTime;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private PlayerStateAnimator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerStateAnimator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Enter()
    {
    }


    public void CloseCollider()
    {
        
    }

    public void Exit()
    {
        _playerAnimator.StopRollAnimation();
        _currentTime = 0;
    }

    public void Roll()
    {
        _speed = _curve.Evaluate(_currentTime);
        _currentTime += Time.deltaTime;
        var offset = _speed * _direction * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }
    
    public void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            _direction = -transform.forward;
            RollAnimation(direction);
            return;
        }
        _direction = direction;
        transform.rotation = Quaternion.LookRotation(direction);
        RollAnimation(_direction);
    }

    private void BackRoll()
    {
    }
    private void RollAnimation(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            _playerAnimator.StartBackRollAnimation();
        }
        _playerAnimator.StartRollAnimation();
    }

    public void EndRolling()
    {
        EndBehaviour?.Invoke();
    }
}
