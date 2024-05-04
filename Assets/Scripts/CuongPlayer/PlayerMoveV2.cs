using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveV2 : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] KeyCode runKey = KeyCode.X;
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;
    private float _horizontalInput;
    private float _verticalInput;

    private Animator _animator;
    private bool _isRunning;

    // Start is called before the first frame update
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        // if(_horizontalInput > 1)
        _direction = new Vector3(_horizontalInput, _verticalInput, 0);
        _animator.SetFloat("x", _horizontalInput);
        _animator.SetFloat("y",  _verticalInput);
        
        if(Input.GetKey(runKey)){
            // _animator.SetFloat("x", 1);
            _isRunning = true;
            _animator.SetFloat("x", _horizontalInput*2);
            _animator.SetFloat("y",  _verticalInput*2);
        }
        else if(Input.GetKeyUp(runKey)){
            // _animator.SetBool("isRunning", false);
            _isRunning = false;

        }


    }

    private void FixedUpdate() {
        if(_direction.x != 0 && _direction.y != 0){
            _direction /= Mathf.Sqrt(2);
        }
        float currentSpeed = speed;
        if(_isRunning){
            currentSpeed *= 2f;
            
        }
        _rigidbody.velocity = _direction * currentSpeed;
    }
}
