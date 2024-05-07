using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState: CuongState
{
    Rigidbody2D _rigidbody;
    protected Animator _animator;

    // public enum Direction{
    //     IHorizontal,
    //     IVertical
    // }
    protected static float _directionX;
    protected static float _directionY;

    private float _threshold;

    // protected Direction direction;

    public float GetThreshold()
    {
        return _threshold;
    }

    
    

    public MoveState(float threshold, Rigidbody2D rigidbody, Animator animator)
    {
        _threshold = threshold;
        _animator = animator;
        _rigidbody = rigidbody;
    }
    public void Move()
    {
        _rigidbody.velocity = NormalizeVector(_directionX, _directionY) * _threshold;
    }

    protected Vector2 NormalizeVector(float directionX, float directionY)
    {
        float normalizedX = directionX, normalizedY = directionY;
        if(normalizedX != 0 && normalizedY != 0){
            normalizedX/=Mathf.Sqrt(2);
            normalizedY/=Mathf.Sqrt(2);

        }
        return new Vector2(normalizedX, normalizedY);
    }

    public void SetXY(float x, float y)
    {
        _directionX = x;
        _directionY = y;
        _animator.SetFloat("x", x);
        _animator.SetFloat("y", y);
    }

    public override void EnterState()
    {
        // throw new System.NotImplementedException();
        
    }

    public override void ExitState()
    {
        // throw new System.NotImplementedException();
    }

    public override void Do()
    {
        Move();
    }
}
