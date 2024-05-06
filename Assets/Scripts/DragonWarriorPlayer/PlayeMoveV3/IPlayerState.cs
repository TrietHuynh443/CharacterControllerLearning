using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayerState
{
    protected Rigidbody2D _rigidbody;
    protected Animator _animator;

    protected static bool _onGround = true;

    protected Vector2 _direction = Vector2.zero;

    public IPlayerState(Rigidbody2D rigidbody, Animator animator)
    {
        _rigidbody = rigidbody;
        _animator = animator;
    }

    public abstract void EnterState();
   
    public abstract void Update();
    public virtual void FixedUpdate(){
        _rigidbody.velocity = _direction;
    }
    public static bool IsGrounded(){
        return _onGround;
    }
    public abstract void ExitState();


}
