using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore()
    {
        if (ScoreTracker.highScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", ScoreTracker.highScore);
        }
        Debug.Log(PlayerPrefs.GetInt("highScore"));
    }

    public void LoadSettings()
    {
        Debug.Log(PlayerPrefs.GetInt("highScore"));
        ScoreTracker.highScore = PlayerPrefs.GetInt("highScore");
    }
}
