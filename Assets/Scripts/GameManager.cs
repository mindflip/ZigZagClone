using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;
    private int highScore;

    private void Awake()
    {
        // PlayerPrefs.DeleteAll();
        // get high score
        getHighScore();
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }

        if(score > highScore)
            highScoreText.text = score.ToString();
    }

    public void EndGame()
    {
        setHighScore();

        SceneManager.LoadScene(0);
    }
    
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void getHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore.ToString();
    }

    public void setHighScore()
    {
        if (score > highScore)
            PlayerPrefs.SetInt("highScore", score);
    }
}