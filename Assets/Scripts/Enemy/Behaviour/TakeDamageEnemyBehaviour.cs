using System;
using DefaultNamespace;
using Enemy.Animation;
using UnityEngine;

public class TakeDamageEnemyBehaviour : MonoBehaviour, ITakeDamageEnemyBehaviour
{
    public event Action EndBehaviour;

    private EnemyStateAnimator _stateAnimation;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _stateAnimation = GetComponent<EnemyStateAnimator>();
    }

    public void Enter() 
    {
    }

    public void Exit() => 
        _rigidbody.velocity = Vector3.zero;

    public void ApplyDamage(Rigidbody attachedBody, int damage)
    {
        _stateAnimation.StartApplyDamageAnimation();
        if(attachedBody != null)
            CalculatePhysics(attachedBody);
    }
    public void ApplyDamage(int damage)
    {
    }

    private void CalculatePhysics(Rigidbody attachedBody)
    {
        var direction = _transform.position - attachedBody.position;
        direction.y = 0;
        _rigidbody.AddForce(direction.normalized * 2, ForceMode.Impulse);
    }

    public void EndTakeDamageAnimation() => 
        EndBehaviour?.Invoke();
}