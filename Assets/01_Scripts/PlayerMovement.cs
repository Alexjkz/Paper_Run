using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask groundLayer;


    private Rigidbody2D rigidbodyMario;
    private PlayerControls controls;
    private Animator animatorMario;
    private int statoMario;

    private bool _jumpInput;
    private float _moveInput;
    private bool reverse = false;





    void Awake()
    {
        //input = new MyInputSystem();

        controls = new PlayerControls();

        rigidbodyMario = GetComponent<Rigidbody2D>();
        animatorMario = GetComponent<Animator>();
        statoMario = animatorMario.GetInteger("StateMarioRed");

        controls.MyInputSystem.Movement.performed += ctx => _moveInput = ctx.ReadValue<float>();
        controls.MyInputSystem.Movement.canceled += ctx => _moveInput = 0.0f;

        controls.MyInputSystem.Jump.performed += ctx => _jumpInput = true;
        controls.MyInputSystem.Jump.canceled += ctx => _jumpInput = false;

        //_moveInput = 1.0f;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }



    void Update()
    {

        Debug.Log(_jumpInput);
        Debug.Log(_moveInput);


        // Movimento
        Vector3 movement = new Vector3(_moveInput, 0.0f, 0.0f);

        // Animazioni movimento
        transform.Translate(movement * _speed * Time.deltaTime);

        // Animazioni movimento
        if(isItGrounded() && _moveInput > 0.0f)
        {
            animatorMario.SetInteger("StateMarioRed",1);
            if(reverse == true)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                reverse = false;
            }
            
            reverse = false;
        }
        else if(isItGrounded() && _moveInput < 0.0f)
        {
            animatorMario.SetInteger("StateMarioRed",1);
            if(reverse == false)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                reverse = true;
            }
            
        }
        else if(isItGrounded() == false)
        {
            animatorMario.SetInteger("StateMarioRed",2);
        }
        else
        {
            animatorMario.SetInteger("StateMarioRed",0);
        }

        // Salto
        if(isItGrounded() && _jumpInput)
        {
            rigidbodyMario.AddForce(new Vector3(0.0f, _jumpForce, 0.0f), ForceMode2D.Impulse);
            _jumpInput = false;
        }
        Debug.Log(isItGrounded());

        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);

    }

    
    public bool isItGrounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer))
        {
            Debug.Log("IsGrounded");
            return true;
        }
        else
        {
            Debug.Log("IsNotGrounded");
            return false;
        }

    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireCube(transform.position-transform.up * groundCheckDistance, boxSize);
    // }
    

    // private void OnCollisionEnter2D(Collision2D other)
    // {
        
    //     if(other.gameObject.CompareTag("Terreno"))
    //     {
    //         isGrounded = true;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     Debug.Log("DIOBESTIA");
    //     if(other.gameObject.CompareTag("Terreno"))
    //     {
    //         isGrounded = false;
    //     }
    // }
}
