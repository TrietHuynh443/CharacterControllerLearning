using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IPlayerState
{
    private float _jumpForce = 0f;
    // private bool _onGround = true;

    private bool _startJumping;
    private Vector2 _force;
    private BoxCollider2D _footCollider;

    private int _jumpCounter = 2;

    private int maxJump = 2;
    // private bool _isNextJump = false;

    public JumpingState(Rigidbody2D rigidbody, Animator animator, BoxCollider2D footCollider, float jumpForce, int jumpCounter) : base(rigidbody, animator)
    {
        // _onComplete += onComplete;
        _footCollider = footCollider;
        _jumpForce = jumpForce;
        // _nextState = this;
        maxJump = 2;
        _jumpCounter = jumpCounter;

    }

    
    
    public void SetGrouded(bool isGrounded){
        _onGround = isGrounded;
    }
    public override void EnterState()
    {
        --_jumpCounter;
        _startJumping = true;
    }

    
    public void ResetCounter(){
        _jumpCounter = maxJump;
    }

    public override void ExitState()
    {
        // _startJumping = false;
    }
    
    public override void FixedUpdate()
    {
        // Debug.Log("Fix update jump");
        // throw new System.NotImplementedException();

        if(!_startJumping){
            if(!IsGrounded()){
                _direction.y -= _rigidbody.gravityScale;
            }
            else{
                ResetCounter();
                _direction.y = 0;
            }
        }
        else{
            _startJumping = false;
            StartJump();
        }
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _direction.y);
    
    }

    public void SetJumpForce(float jumpForce){
        _jumpForce = jumpForce;
    }
    public void StartJump(){
    
        // _startJumping = true;
        _direction.y = -1;
         _direction += Vector2.up*_jumpForce;
         
        // _rigidbody.AddForce(_force, ForceMode2D.Impulse);
        _onGround = false;
        _animator.SetBool("onGround", false);
           
    }

    void CheckGround(){
        Bounds bounds = _footCollider.bounds;
        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0f, LayerMask.GetMask("Ground"));
        if(hit.collider == null){
            _onGround = false;
        }
        else{
            _onGround = true;
            // _startJumping = false;
        }
    }
    public override void Update()
    {
        // _startJumping = true;
        
        // throw new System.NotImplementedException();
    }

    public int GetJumpCounter()
    {
        return _jumpCounter;
    }

    public void SetJump(bool v)
    {
        _startJumping = v;
    }

    internal bool IsJumping()
    {
        return _startJumping;
    }
}
