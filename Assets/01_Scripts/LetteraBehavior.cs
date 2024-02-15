using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetteraBehavior : MonoBehaviour
{
    [SerializeField] private GameObject letteraPag1;
    [SerializeField] private GameObject letteraPag2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().tag == "Player")
        {
            letteraPag1.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().tag == "Player")
        {
            letteraPag1.gameObject.SetActive(false);
            letteraPag2.gameObject.SetActive(false);
        }
    }

    public void OnClickOfPage1()
    {
        letteraPag1.gameObject.SetActive(false);
        letteraPag2.gameObject.SetActive(true);
    }

    public void OnClickOfPage2()
    {
        letteraPag1.gameObject.SetActive(false);
        letteraPag2.gameObject.SetActive(false);
    }
}
