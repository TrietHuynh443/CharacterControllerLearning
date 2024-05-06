using System.Collections;
using System.Collections.Generic;
using charactercontroller.dragonwarrior.states;
using UnityEngine;

public class IdleState : IPlayerState
{
    public IdleState(Rigidbody2D rigidbody, Animator animator) : base(rigidbody, animator)
    {
        // _nextState = this;
    }

    public override void EnterState()
    {

        _animator.SetBool("isIdle", true);
    }

    public override void ExitState()
    {
        _animator.SetBool("isIdle", false);
    }

    public override void FixedUpdate()
    {
        // throw new System.NotImplementedException();
    }

    public override void Update()
    {
        // throw new System.NotImplementedException();
    }
}
