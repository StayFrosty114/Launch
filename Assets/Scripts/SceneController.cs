using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject controlScreen;
    public GameObject creditScreen;
    private SettingsManager sM;

    private void Start()
    {
        sM = FindObjectOfType<SettingsManager>();

        if (controlScreen != null)
            controlScreen.SetActive(false);

        if (creditScreen != null)
            creditScreen.SetActive(false);

    }

    // Menu Functions
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlScreen()
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
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");

    }

    public void Quit()
    {
        Application.Quit();
    }

}
