using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBoxBehavior : MonoBehaviour
{
    private Animator animatorCassetta;
    // Start is called before the first frame update
    void Start()
    {
        animatorCassetta = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().tag == "Player")
        {
            animatorCassetta.SetTrigger("OpenBox");
        }
    }
}
