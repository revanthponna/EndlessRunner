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
        score++; // increasing the score with each coin collected
        scoreText.text = "Score : " + score;
        PlayerPrefs.SetInt("score", score);
        // increasing the player's speed as the game progresses
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
            scoreText.text = "Score : " + PlayerPrefs.GetInt("score"); // displaying the final score
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the high score using PlayerPrefs
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore");
    }
}
