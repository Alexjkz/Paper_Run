using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MovimentoEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float fallingTreshold = -3.5f;
    private Animator animatorNutria;
    private Collider2D myCapsuleCollider;
    private Rigidbody2D rigidbodyNutria;
    private float nutriaYaxis;
    private Transform nutriaPosition;

    


    // Vector3 movement = new Vector3(-1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        animatorNutria = GetComponent<Animator>();
        rigidbodyNutria = GetComponent<Rigidbody2D>();
        nutriaPosition = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(movement * speed * Time.deltaTime);

        // Morte
        nutriaYaxis = nutriaPosition.position.y;
        if(nutriaYaxis < fallingTreshold)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rigidbodyNutria.velocity = new Vector2(-1f * speed, rigidbodyNutria.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            animatorNutria.SetInteger("NutriaState",1);
            speed = 0;
        }
    }

    // ---- ATTIVO FUNZIONE ESTERNAMENTE ---- MI sa che non la uso questa 
    public void EnemyController()
    {
        animatorNutria.SetInteger("NutriaState",1);
        speed = 0;
    }
}
