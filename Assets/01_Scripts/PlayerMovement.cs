using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject pannelloSconfitta;
    [SerializeField] private GameObject pannelloVincita;
    [SerializeField] private GameObject letteraInMano;
    [SerializeField] private float fallingTreshold = -5.0f;


    private Rigidbody2D rigidbodyMario;
    private Transform marioPosition;
    private float marioYAxis;
    private PlayerControls controls;
    private Animator animatorMario;
    private int statoMario;
    private bool isJumping = false;
    private bool _jumpInput;
    private float _moveInput;
    private bool _pauseInput;
    private bool reverse = false;
    public Vector3 marioMovement;
    private AudioSource effettoSalto;



    void Awake()
    {
        Time.timeScale = 1f;
        controls = new PlayerControls();

        rigidbodyMario = GetComponent<Rigidbody2D>();
        animatorMario = GetComponent<Animator>();
        statoMario = animatorMario.GetInteger("StateMarioRed");
        marioPosition = GetComponent<Transform>();
        effettoSalto = GetComponent<AudioSource>();

        controls.MyInputSystem.Movement.performed += ctx => _moveInput = ctx.ReadValue<float>();
        controls.MyInputSystem.Movement.canceled += ctx => _moveInput = 0.0f;

        controls.MyInputSystem.Jump.performed += ctx => _jumpInput = true;
        controls.MyInputSystem.Jump.canceled += ctx => _jumpInput = false;

        controls.MyInputSystem.Pause.performed += ctx => _pauseInput = true;
        controls.MyInputSystem.Pause.canceled += ctx => _pauseInput = false;
    }



    void OnEnable()
    {
        controls.Enable();
    }



    void OnDisable()
    {
        controls.Disable();
    }



    void Start()
    {
        pannelloSconfitta.SetActive(false);
        pannelloVincita.SetActive(false);
    }

    void FixedUpdate()
    {

        rigidbodyMario.velocity = marioMovement;


                // Salto
        if(isItGrounded() && _jumpInput)
        {
            rigidbodyMario.velocity = new Vector2(rigidbodyMario.velocity.x, _jumpForce);
            isJumping = true;
            StartCoroutine(jumpAnimation());
            _jumpInput = false;
            
        }
        Debug.Log(isItGrounded());
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);

    }

    void Update()
    {
        // Movimento
        marioMovement = new Vector2(_moveInput * _speed, rigidbodyMario.velocity.y);
        //transform.Translate(marioMovement * _speed * Time.deltaTime);

        // Animazioni
        if(isItGrounded() && _moveInput > 0.0f && isJumping == false)
        {
            letteraInMano.gameObject.SetActive(false);
            animatorMario.SetInteger("StateMarioRed",1);
            if(reverse == true)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                reverse = false;
                
            }
            reverse = false;
        }
        else if(isItGrounded() && _moveInput < 0.0f && isJumping == false)
        {
            letteraInMano.gameObject.SetActive(false);
            animatorMario.SetInteger("StateMarioRed",1);
            if(reverse == false)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                reverse = true;
                
                
            }      
        }
        else if(isItGrounded() && _moveInput == 0.0f && isJumping == false)
        {
            animatorMario.SetInteger("StateMarioRed",0);
            
        }
        else
        {
            Debug.Log("Non sono grounded");
        }


        
        // Morte
        marioYAxis = marioPosition.position.y;
        if(marioYAxis < fallingTreshold)
        {
            YouLost();
        }

        // Pausa
        if(_pauseInput)
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }



    private IEnumerator jumpAnimation()
    {
        effettoSalto.Play();
        animatorMario.SetInteger("StateMarioRed",2);
        yield return new WaitForSeconds(0.5f);
        animatorMario.SetInteger("StateMarioRed",0);
        isJumping = false;
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



    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "NutriaDamage")
        {
            YouLost();         
        }
    }



    private void YouLost()
    {
        Debug.Log("YOU LOST");
        Time.timeScale = 0f;
        pannelloSconfitta.SetActive(true); 
    }
}
