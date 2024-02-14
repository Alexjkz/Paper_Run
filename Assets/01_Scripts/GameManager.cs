using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
