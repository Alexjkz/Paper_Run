using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MovimentoEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float fallingTreshold = -3.5f;
    [SerializeField] GameObject player;
    [SerializeField] float distanzaAttivazioneNutria = 10f;
    private Animator animatorNutria;
    private Collider2D myCapsuleCollider;
    private Rigidbody2D rigidbodyNutria;
    private float nutriaYaxis;
    private Transform nutriaPosition;
    private bool startMoving = false;
    private Transform playerPosition;
    private AudioSource audioPlayerSuonoMorte;


    

    // Vector3 movement = new Vector3(-1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        animatorNutria = GetComponent<Animator>();
        rigidbodyNutria = GetComponent<Rigidbody2D>();
        nutriaPosition = GetComponent<Transform>();

        playerPosition = player.GetComponent<Transform>();
        audioPlayerSuonoMorte = GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Distanza {nutriaPosition.position.x - playerPosition.position.x}");
        //transform.Translate(movement * speed * Time.deltaTime);
        if(nutriaPosition.position.x - playerPosition.position.x < distanzaAttivazioneNutria && !startMoving)
        {
            startMoving = true;
        }
        

        // Morte
        nutriaYaxis = nutriaPosition.position.y;
        if(nutriaYaxis < fallingTreshold)
        {
            gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        if (startMoving)
        {
            rigidbodyNutria.velocity = new Vector2(-1f * speed, rigidbodyNutria.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform childTransform = transform.Find("NutriaPiedi");
        if(collision.collider.tag == "Player")
        {
            audioPlayerSuonoMorte.Play();
            animatorNutria.SetInteger("NutriaState",1);
            speed = 0;
            rigidbodyNutria.simulated = false;
            childTransform.GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

        }
    }

    // // ---- ATTIVO FUNZIONE ESTERNAMENTE ---- MI sa che non la uso questa 
    // public void EnemyController()
    // {
    //     animatorNutria.SetInteger("NutriaState",1);
    //     speed = 0;
    // }
}
