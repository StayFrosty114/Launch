using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int highScore = 0;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
