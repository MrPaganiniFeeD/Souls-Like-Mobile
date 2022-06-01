using PlayerLogic;
using PlayerLogic.State;
using PlayerLogic.States;
using UnityEngine;
using Zenject;

public class ImpulseBeginAnimation : StateMachineBehaviour
{
    [SerializeField] private float _force;
    
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    //[Inject]
    public void Constructor(Player player)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
        _transform = player.GetComponent<Transform>();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _direction = _transform.forward; 
        _rigidbody.AddForce(_direction * _force, ForceMode.Impulse);
    }
}
