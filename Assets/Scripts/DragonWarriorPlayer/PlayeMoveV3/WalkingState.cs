using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkingState : IPlayerState
{
    private float speed;
    private float _horizontalInput;
    private SpriteRenderer _renderer;

    public void SetInput(float input, float speed){
        _horizontalInput = input;
        this.speed = speed;
        // Debug.Log("Speed " + speed);

    }
    public WalkingState(Rigidbody2D rigidbody, Animator animator, SpriteRenderer renderer) : base(rigidbody, animator)
    {
        _renderer = renderer;
        // _nextState = this;
    }

    // Start is called before the first frame update
    public override void EnterState()
    {
        _animator.SetBool("isWalking", true);
        // Debug.Log("Out of Idle");

        // throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        _animator.SetBool("isWalking", false);
        // _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        // throw new System.NotImplementedException();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // throw new System.NotImplementedException();
        if(Mathf.Abs(_horizontalInput) >= 0.1f){

        
            EnterState();
            _renderer.flipX = _horizontalInput < 0;
            _direction.x  = _horizontalInput*speed;
            _rigidbody.velocity = _direction;
        }
        else{
            ExitState();
            return;
        }
        
    }

    public override void Update()
    {
        // bool isIdle = !(Mathf.Abs(_horizontalInput) > 0.1f );
        _animator.SetFloat("x", _horizontalInput);        
        // Debug.Log(_animator.GetFloat("x"));
    }
}
