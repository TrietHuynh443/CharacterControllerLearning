using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuongPlayerMoveV3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 10f;

    CuongState _currentState;
    RunState _runState;
    MoveState _moveState;
    float _horizontalInput;
    float _verticalInput;
    void Start()
    {
        _runState = new RunState(_speed, _rigidbody, _animator);
        _moveState = new MoveState(_speed*1.5f, _rigidbody, _animator);
        _currentState = _moveState;
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
        _moveState.SetXY(_horizontalInput, _verticalInput);

        if(Input.GetKey("x")){
            _runState.AnimatorUpdate();
            UpdateState(_runState);
            
            // _currentState = _runState;
        }
        if(Input.GetKeyUp("x")){
            UpdateState(_moveState);
        }

        // _moveState.SetXY(_horizontalInput, _verticalInput);
    }

    private void UpdateState(CuongState state)
    {
        if(_currentState != state){
            _currentState.ExitState();
            _currentState = state;
            _currentState.EnterState();
        }
    }

    private void FixedUpdate() {
        _currentState.Do();
    }


}
