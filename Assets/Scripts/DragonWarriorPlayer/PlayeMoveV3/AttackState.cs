using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IPlayerState
{
    float _attackClipLength = 0f;
    float _startTime = 0f;
    public AttackState(Rigidbody2D rigidbody, Animator animator) : base(rigidbody, animator)
    {
    }

    // Start is called before the first frame update
    public override void EnterState()
    {
        // throw new System.NotImplementedException();
        _animator.SetBool("isAttacking", true);
        AnimatorClipInfo[] currentClipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        _attackClipLength = currentClipInfo[0].clip.length;
        _startTime = Time.time;

        //Access the Animation clip name
    }

    public override void ExitState()
    {
        _animator.SetBool("isAttacking", false);

    }

    public override void Update()
    {
        // throw new System.NotImplementedException();
        if (Time.time > _startTime + _attackClipLength)
        {
            ExitState();

        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
    }

    public bool IsAttacking()
    {
        return _animator.GetBool("isAttacking");
    }
}
