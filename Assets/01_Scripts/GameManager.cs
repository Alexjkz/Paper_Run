using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textboxNumeroMonete;
    public int contatoreMonete;
    private int moneteIncrement;
    private AudioSource audioPlayer;
    
    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    
    void Start()
    {
        contatoreMonete = 0;
        moneteIncrement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textboxNumeroMonete.text = contatoreMonete.ToString();
        if(contatoreMonete > moneteIncrement)
        {
            audioPlayer.Play();
            moneteIncrement = contatoreMonete;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }


    //     public void Pausa()
    // {
        
    //     if (Time.timeScale == 0) 
    //     {
    //         Time.timeScale = 1;
    //         buttonPausa.image.sprite = spritePausa;            
    //     }
    //     else 
    //     {
    //         Time.timeScale = 0;
    //         buttonPausa.image.sprite = spritePlay;
            
    //         print("Pausa");
    //     }
    // }
}
