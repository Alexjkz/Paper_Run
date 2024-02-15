    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBoxBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bustaLuminosa;
    [SerializeField] private GameObject pannelloVittoria;
    [SerializeField] private GameObject letteraInMano;
    [SerializeField] private GameObject letteraCheEntraNellaCassetta;

    
    private Animator animatorCassetta;
    private Animator animatorBusta;
    private Animator animatorEntrataCassetta;
    // Start is called before the first frame update
    void Start()
    {
        bustaLuminosa.gameObject.SetActive(false);
        animatorCassetta = GetComponent<Animator>();
        animatorBusta = bustaLuminosa.GetComponent<Animator>();
        animatorEntrataCassetta = letteraCheEntraNellaCassetta.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().tag == "Player")
        {
            StartCoroutine(animazioneFinale());
            animatorCassetta.SetTrigger("OpenBox");
        }
    }

    private IEnumerator animazioneFinale()
    {
        animatorCassetta.SetTrigger("OpenBox");
        yield return new WaitForSeconds(0.5f);

        letteraInMano.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        bustaLuminosa.gameObject.SetActive(true);
        letteraInMano.gameObject.SetActive(false);
        //animatorBusta.SetTrigger("StartAnimation");
        yield return new WaitForSeconds(1.5f);
        bustaLuminosa.gameObject.SetActive(false);

        letteraCheEntraNellaCassetta.gameObject.SetActive(true);
        //animatorEntrataCassetta.SetTrigger("Entra");
        yield return new WaitForSeconds(1f);

        animatorCassetta.SetTrigger("CloseBox");
        yield return new WaitForSeconds(1);

        YouWon();
    }

    private void YouWon()
    {
        Debug.Log("YOU WON");
        Time.timeScale = 0f;
        pannelloVittoria.SetActive(true);
    }
}
