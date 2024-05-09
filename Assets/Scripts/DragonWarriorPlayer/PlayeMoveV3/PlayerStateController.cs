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
    
    private AttackState attackState;
    private Action _stateAction;

    private bool _isDoing = false;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        walkingState = new WalkingState(_rigidbody, animator, renderer);
        jumpingState = new JumpingState(_rigidbody, animator, footCollider, jumpForce, jumpCounter);
        floatingState = new FloatingState(_rigidbody, animator);
        attackState = new AttackState(_rigidbody, _animator);
        currentState = walkingState;
    }

    // Update is called once per frame

    void Update()
    {
       if(!attackState.IsAttacking())
            InputHandler();
        // currentState.Update();
        floatingState.CheckGround(footCollider);
        currentState.Update();

    }
    
    private void InputHandler()
    {
        
        _horizontalInput = Input.GetAxis("Horizontal");

        walkingState.SetInput(_horizontalInput, speed);
        
        currentState = walkingState;
        if(Input.GetKeyDown(KeyCode.Space)) {
           
            //firstjump
            if(IPlayerState.IsGrounded()){
                Debug.Log("On ground");
                jumpingState.SetJumpForce(jumpForce);
                
                currentState = jumpingState;
                
                jumpingState.EnterState();

            }
            else{
                Debug.Log("floating time: " + floatingState.GetFloatingTime() + " jump counter " + jumpingState.GetJumpCounter());
                if(coyateTime > floatingState.GetFloatingTime() && jumpingState.GetJumpCounter() > 0){
                    jumpingState.SetJumpForce(jumpForce);
                    currentState = jumpingState;
                    jumpingState.EnterState();
                }
            }
        }
        
        AttackInputHandler();
        
    }

    private void AttackInputHandler()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            currentState = attackState;
            attackState.EnterState();
        }
    }

    

    void FixedUpdate()
    {
        currentState.FixedUpdate();
        // floatingState.FixedUpdate();
        jumpingState.FixedUpdate();
        
        
    }
}

