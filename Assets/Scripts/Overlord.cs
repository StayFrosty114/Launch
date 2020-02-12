﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject deathScreen;

    public float moveSpeed = 0.002f;
    private float accelerateDelay = 15;

    public bool gameStarted = false;

    private SettingsManager sM;
    private GoogleHandler gH;
    // Achievement Variables. 0 = locked, 1 = unlocked
    public int gamesPlayed;
    public int launch50;
    public int launch100;

    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindObjectOfType<SettingsManager>();
        gH = GameObject.FindObjectOfType<GoogleHandler>();
        Time.timeScale = 1.0f;
        deathScreen.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        gameStarted = true;
        StartCoroutine(Accelerate());
    }

    private IEnumerator Accelerate()
    {
        while (gameStarted == true)
        {
            yield return new WaitForSeconds(accelerateDelay);
            Debug.Log("Speeding up" + moveSpeed);
            moveSpeed *= 1.5f;
            if (moveSpeed >= 0.01)
            {
                accelerateDelay = 30;
            }
            if (moveSpeed >= 0.02)
            {
                StopCoroutine(Accelerate());
            }
        }
    }

    // Adds a point to the score every time the player moves up a platform.
    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Death()
    {
        if (score >= ScoreTracker.highScore)
        {
            ScoreTracker.highScore = score;
            sM.SaveHighScore();
        }
        if (score >= 50 && launch50 <= 0)
        {

        }
        Time.timeScale = 0.0f;
        deathScreen.SetActive(true);
        UpdateAchievements();
    }
    private void UpdateAchievements()
    {
        if (gamesPlayed <= 0)
        {
            gH.UpdateAchievement("CgkIivzD8KwEEAIQAA");
            gamesPlayed++;
            sM.SaveInt("gamesPlayed", gamesPlayed);
            Debug.Log("Played a game");
        }
    }
}
