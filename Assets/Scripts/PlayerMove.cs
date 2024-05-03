using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private float _jumpForce;
    [SerializeField]private float _gravity;
    [SerializeField]private float _gravityMultiplier;
    [SerializeField]private KeyCode rightKey;
    [SerializeField]private KeyCode leftKey;
    [SerializeField]private KeyCode jumpKey;
    [SerializeField]private int maxJumpCounter = 2; 
    [SerializeField]private float coyateTime = 0.3f;
    [SerializeField]private float groundDistance = 1f;

    [SerializeField] private BoxCollider2D footCollider;

    // private CharacterController _characterController;
    private Rigidbody2D _rigidbody;
    // private BoxCollider2D _collider;
    // private Transform _foot;
    private Transform _head;
    private bool _isGrounded = true;
    private Vector2 _direction = Vector2.zero;
    // private Vector2 _veloctity = Vector2.zero;
    private SpriteRenderer _spriteRenderer;
    private float _horizontalInput;
    private bool _isJumping;

    private bool _isCrounched = false;
    
    private int _jumpCounter = 0;
    private float _startFloatingTime = 0f;
    private float _endfloatingTime= 0;

    // Start is called before the first frame update
    void Start()
    {
        // _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        // _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody.isKinematic = false;
        // _foot = transform.Find("FootCollider").transform;
        _head = transform.Find("HeadCollider").transform;
        // Debug.Log(_foot.name);
      
        
    }

    private void Moving()
    {
        
        if (_horizontalInput != 0)
        {    _spriteRenderer.flipX = _horizontalInput < 0;
              _direction.x = _horizontalInput*_speed*Time.deltaTime;
        }
        else{
             _direction.x = 0;
        }
         
    }

    private void InputHandler()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCounter < maxJumpCounter && (_endfloatingTime - _startFloatingTime) <= coyateTime)
        {
            
            _isJumping = true;
        
            _jumpCounter++;
            Debug.Log("jumpCounter value " + _jumpCounter);
        }
        if(Input.GetKey(KeyCode.DownArrow) && _isGrounded){
            _isCrounched = true;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            _isCrounched = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();

    }

    private void FixedUpdate() {
        Moving();

        Jumping();

        Crouching();

        ApplyChange();
    }

    private void Crouching()
    {
        
    
        _head.GetComponent<Collider2D>().enabled = !_isCrounched;

    }

    private void ApplyChange()
    {
        if(!_isGrounded){
            // if(_isGrounded
            // Debug.Log("Not grounded");
            HandleGravity();
        }
        // else{
        //     _direction.y = 0;
        // }
        _rigidbody.velocity = _direction;
        // _characterController.Move(_direction*Time.deltaTime);
    }

    bool CheckGround()
    {

        RaycastHit2D hit = Physics2D.BoxCast(footCollider.bounds.center, footCollider.bounds.size, 0f, Vector2.down, groundDistance, LayerMask.GetMask("Ground"));
    
        // Debu(_foot.position, Vector2.down, Color.white);
        
        if(hit.collider == null){
            // Debug.Log("Cannot detach ground localascaley= " +  _foot.localScale.y);
            // Debug.Log("Floating time " + _floatingTime);
            if(_startFloatingTime == 0f){
                _startFloatingTime = Time.time;
            }
            _endfloatingTime = Time.time;
            _isGrounded = false;
        }
        else{
            // _rigidbody.gravityScale = _gravity;
            // Debug.Log("onGround");
            _startFloatingTime = 0f;
            _endfloatingTime = 0f;
            _isGrounded = true;
            _jumpCounter = 0;
        }
        Debug.Log("Floating time " + (_endfloatingTime - _startFloatingTime));
        return _isGrounded;
    }
    
    void Jumping()
    {
        if(!_isJumping){
            CheckGround();
            return;
        }
        
        
        Debug.Log("Start Jumping");
        // _isJumping = true;
        _direction.y = _jumpForce;
        // HandleGravity();

        _isJumping = false;

    }
    private void HandleGravity()
    {
        
        _direction.y -= _gravity*Time.deltaTime*_gravityMultiplier;

    }
}
