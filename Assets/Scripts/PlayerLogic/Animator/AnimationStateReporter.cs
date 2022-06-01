using System;
using UnityEngine;

namespace DefaultNarmespace.Player.AnimatorReporter
{
    public class AnimationStateReporter : StateMachineBehaviour
    {
        private IAnimationStateReader _animationReader;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            FindAnimationReader(animator);
            
            _animationReader.OnStateEnter(stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            FindAnimationReader(animator);
            
            _animationReader.OnStateExit(stateInfo);
        }


        private void FindAnimationReader(Component animator)
        {
            _animationReader = animator.gameObject.GetComponent<IAnimationStateReader>();
        }
    }
}