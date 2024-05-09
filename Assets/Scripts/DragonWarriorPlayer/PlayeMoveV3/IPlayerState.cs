using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayerState
{
    public enum IActionParameters{
        None = 0,
        Jump = 1,
        Attack = 2,
    }
    protected Rigidbody2D _rigidbody;
    protected Animator _animator;

    protected static bool _onGround = true;

    protected Vector2 _direction = Vector2.zero;

    private Action _action;

    bool _isDoing;

    public IPlayerState(Rigidbody2D rigidbody, Animator animator)
    {
        _rigidbody = rigidbody;
        _animator = animator;
    }

    public abstract void EnterState();

    public virtual void AddAction(Action action){
        _isDoing = true;

        _action += action;
    }

    public virtual void RemoveAction(Action action){
        _isDoing = false;
        _action -= action;
    }

    public bool IsDoing(){
        return _isDoing;
    }
   
    public abstract void Update();
    public virtual void FixedUpdate(){
        _action?.Invoke();
        // _isDoing = false;
        // RemoveAction(_action);
        // _rigidbody.velocity = _direction;
    }
    public static bool IsGrounded(){
        return _onGround;
    }
    public abstract void ExitState();


}
