using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // public int launch50 = 0;
    // public int launch100 = 0;
    // public int gamesPlayed = 0;

    private GoogleHandler googleHandler;

    public bool mute = false;
    public Sprite soundOn;
    public Sprite soundOff;
    private Button soundButton;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        googleHandler = GetComponent<GoogleHandler>();
        googleHandler.StartGooglePlayServices();
        LoadSettings();
    }

    public void SaveHighScore()
    {
        if (ScoreTracker.highScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", ScoreTracker.highScore);
        }
        Debug.Log(PlayerPrefs.GetInt("highScore"));
    }

    public void SaveInt(string name, int i)
    {
        PlayerPrefs.SetInt(name, i);
    }

    public void LoadSettings()
    {
        Debug.Log(PlayerPrefs.GetInt("highScore"));
        ScoreTracker.highScore = PlayerPrefs.GetInt("highScore");

        mute = (PlayerPrefs.GetInt("mute") == 1 ? true : false);

    }

    public void LoadOptions()
    {
        soundButton = FindObjectOfType<Mute>().GetComponent<Button>();
        if (mute)
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
    }
    public void ToggleMute()
    {
        soundButton = FindObjectOfType<Mute>().GetComponent<Button>();
        mute = !mute;
        PlayerPrefs.SetInt("mute",(mute == true ? 1 : 0));
        if (mute)
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOn;
        }

    }
}
