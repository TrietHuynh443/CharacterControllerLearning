using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingState : IPlayerState
{
    private float _startFloatingTime = 0f;
    private float _endfloatingTime = 0f;


    public FloatingState(Rigidbody2D rigidbody, Animator animator) : base(rigidbody, animator)
    {
    }
    public void CheckGround(BoxCollider2D footCollider){
        Bounds bounds = footCollider.bounds;
        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0f, LayerMask.GetMask("Ground"));
        if(hit.collider == null){
            _onGround = false;
           _endfloatingTime = Time.time;
        }
        else{
            EnterState();
            _onGround = true;
            // _startJumping = false;
        }
    }

    public override void EnterState()
    {
        _startFloatingTime = Time.time;
        _endfloatingTime = Time.time;

    }

    public override void ExitState()
    {
 
    }

    public float GetFloatingTime(){
        return _endfloatingTime - _startFloatingTime;
    }


  
    public override void FixedUpdate()
    {
        
    }

    public override void Update()
    {
        // throw new System.NotImplementedException();s
    }
}
