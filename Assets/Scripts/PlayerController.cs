﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _moveVector;    
    public float speed;
    public float Jumpforce;
    public float gravity = 9.8f;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController =  GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime );

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    void Update()
    {
        //movement
        _moveVector = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if(Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if(Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }


        //jump
        if(Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -Jumpforce;
        }
    }
}
