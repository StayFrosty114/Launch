using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    // Menu Functions
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlMenu()
    {
        SceneManager.LoadScene("ControlMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
