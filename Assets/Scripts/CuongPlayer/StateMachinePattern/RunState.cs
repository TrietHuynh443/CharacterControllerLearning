using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MoveState
{
    public RunState(float threshold, Rigidbody2D rigidbody, Animator animator) : base(threshold, rigidbody, animator)
    {
    }

    public override void EnterState()
    {
        
        base.EnterState();
    }

    public override void ExitState()
    {
        // _animator.SetBool("isRunning", false);
        base.ExitState();
    }
    public override void Do()
    {
        // base.Do();
       
        // SetXY(_directionX*2, _directionY*2);
        Debug.Log("Running " + _animator.GetFloat("x")+ " " + _animator.GetFloat("y"));

        Move();
    }

    public void AnimatorUpdate()
    {
         _animator.SetFloat("x", _directionX*2);
        _animator.SetFloat("y", _directionY*2);
    }
}
