using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject controlScreen;
    public GameObject creditScreen;

    private void Start()
    {
        controlScreen.SetActive(false);
        creditScreen.SetActive(false);
    }

    // Menu Functions
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlMenu()
    {
        controlScreen.SetActive(true);
    }

    public void CloseControls()
    {
        controlScreen.SetActive(false);
    }

    public void CreditScreen()
    {
        creditScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        creditScreen.SetActive(false);
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
