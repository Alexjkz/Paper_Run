using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetaCollect : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update

    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Moneta Collected");
        if(other.GetComponent<Collider2D>().tag == "Player")
        {
            Debug.Log("Moneta Collected");
            gameManager.contatoreMonete += 1;
            gameObject.SetActive(false);
            
        }
    }
}
