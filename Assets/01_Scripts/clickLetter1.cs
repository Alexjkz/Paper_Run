using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class clickLetter1 : MonoBehaviour
{

    [SerializeField] private GameObject letteraPag2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("ATTIVATAAAAAAAAAA");
        letteraPag2.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
