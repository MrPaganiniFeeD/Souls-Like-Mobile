using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollowBehaviour : IBehaviourState
{
    void Follow(Transform target);
}
