using PlayerLogic;
using PlayerLogic.State;
using PlayerLogic.States;
using UnityEngine;
using Zenject;

public class RollingDuringAnimation : StateMachineBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    
    private float _speed;
    private float _currentTime;
    private Vector3 _direction;
    private Transform _transform;
    private Rigidbody _rigidbody;

    [Inject]
    public void Constructor(Player player)
    {
        _transform = player.GetComponent<Transform>();
        _rigidbody = player.GetComponent<Rigidbody>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _direction = -_transform.forward;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _speed = _animationCurve.Evaluate(_currentTime);
        _currentTime += Time.deltaTime;
        var offset = _speed * _direction * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);  
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _currentTime = 0;
    }
}
