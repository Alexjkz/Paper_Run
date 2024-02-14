using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("DC");
    }

    // Update is called once per frame


    public void RestartGame()
    {
        Debug.Log("AVVIO");
        SceneManager.LoadScene("MainScene");
        
        
    }
}
