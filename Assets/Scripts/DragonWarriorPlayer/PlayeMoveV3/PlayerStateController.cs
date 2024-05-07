using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using charactercontroller.dragonwarrior.states;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] BoxCollider2D footCollider;
    [SerializeField] private float groundDistance;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField]private int jumpCounter = 2;
    [SerializeField] private float coyateTime = 1;
    private IPlayerState currentState;

    private WalkingState walkingState;
    private JumpingState jumpingState;

    private float _horizontalInput;
    

    // private bool _isJumping = false;
    private Rigidbody2D _rigidbody;
    private FloatingState floatingState;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        walkingState = new WalkingState(_rigidbody, animator, renderer);
        jumpingState = new JumpingState(_rigidbody, animator, footCollider, jumpForce, jumpCounter);
        floatingState = new FloatingState(_rigidbody, animator);
    }

    void Update()
    {
       
        InputHandler();
        // currentState.Update();
        floatingState.CheckGround(footCollider);

    }
    
    private void InputHandler()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        walkingState.SetInput(_horizontalInput, speed);
        if(Input.GetKeyDown(KeyCode.Space)) {
           
            //firstjump
            if(IPlayerState.IsGrounded()){
                Debug.Log("On ground");
                jumpingState.SetJumpForce(jumpForce);

                jumpingState.EnterState();

            }
            else{
                Debug.Log("floating time: " + floatingState.GetFloatingTime() + " jump counter " + jumpingState.GetJumpCounter());
                if(coyateTime > floatingState.GetFloatingTime() && jumpingState.GetJumpCounter() > 0){
                    jumpingState.SetJumpForce(jumpForce);

                    jumpingState.EnterState();
                }
            }
        }
        
        
    }

  
    
    void FixedUpdate()
    {
        walkingState.FixedUpdate();
        // floatingState.FixedUpdate();
        jumpingState.FixedUpdate();

    }
}

