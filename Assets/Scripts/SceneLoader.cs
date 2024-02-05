using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    private void Update()
    {
        LoadMenu();
        
    }


    public void LoadNextScene()
    {
        // local int variable that saves the value of the current scene (the one we are in)
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(0);

    }

    public void LoadMenu()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}