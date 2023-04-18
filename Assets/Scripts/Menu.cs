using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        
        //if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        
        Application.Quit();
        Debug.Log("QuitGame");
    }



}
