using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MovimentoEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    private Animator animatorNutria;
    private Collider2D myCapsuleCollider;

    Vector3 movement = new Vector3(-1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        animatorNutria = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            animatorNutria.SetInteger("NutriaState",1);
            movement = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // ---- ATTIVO FUNZIONE ESTERNAMENTE ----
    public void EnemyController()
    {
        animatorNutria.SetInteger("NutriaState",1);
        movement = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
