using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Start()
    {
        canvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        LoadMenu();
        
    }


    public void DeactivateCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void ActivateCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void LoadMenu()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}