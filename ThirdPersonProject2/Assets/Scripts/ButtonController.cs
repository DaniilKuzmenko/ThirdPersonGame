using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button START;
    public Button Quit;

    void Start()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame () {
        SceneManager.LoadScene("Game");
    }

    private void QuitGame () {
        Application.Quit();
    }
}