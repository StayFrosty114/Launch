using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public float moveSpeed = 0.002f;

    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("Speeding up" + moveSpeed);
            moveSpeed *= 1.5f;
            yield return new WaitForSeconds(15);
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
        // Debug.Log("YOU DIED");
    }
}
