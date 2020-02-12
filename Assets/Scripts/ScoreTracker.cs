using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int highScore;
    public Text highScoreText;

    private SettingsManager sM;
    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindObjectOfType<SettingsManager>();
        sM.LoadSettings();
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }
}
