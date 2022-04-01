using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    int highScore;
    public static GameManager inst;
    public Text scoreText;
    public Text highScoreText;
    public PlayerMovement playerMovement;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score : " + score;
        PlayerPrefs.SetInt("score", score);
        // increasing the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Scene current = SceneManager.GetActiveScene();
        if(current.name == "Restart")
        {
            scoreText.text = "Score : " + PlayerPrefs.GetInt("score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore");
    }
}
