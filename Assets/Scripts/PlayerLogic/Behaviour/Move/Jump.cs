using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _maxHeightJump;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    public void Bounce()
    {
        if (_isGrounded)
        {
            var direction = new Vector3(0, _maxHeightJump, 0);
            _animator.SetTrigger("Jump");
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
    private void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, 1.5f) == true)
            _isGrounded = true;
        else
            _isGrounded = false;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }



}
