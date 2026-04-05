using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public int startingLives = 3;
    public int pointsPerBrick = 50;
    
    [Header("UI References")]
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public GameObject winText;
    public GameObject gameOverText;
    private int remainingBricks;
    private int currentLives;
    private int currentScore;
    private bool gameWon = false;
    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        BrickBlock[] bricks = FindObjectsByType<BrickBlock>();
        remainingBricks = bricks.Length;
        
        currentLives = startingLives;
        currentScore = 0;
        
        UpdateLivesUI();
        HideEndMessages();
        
        Debug.Log("Bricks in level: " + remainingBricks);
        Debug.Log("Lives: " + currentLives);
        Debug.Log("Score: " + currentScore);
    }
    void Update()
    {
        if ((gameWon || gameOver) && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void BrickDestroyed()
    {
        if (gameWon || gameOver)
        {
            return;
        }

        remainingBricks--;
        currentScore += pointsPerBrick;
        
        Debug.Log("Remaining bricks: " + remainingBricks);
        Debug.Log("Score: " + currentScore);
        
        UpdateScoreUI();
        
        if (remainingBricks <= 0)
        {
            WinGame();
        }
    }

    public void BallLost()
    {
        if (gameWon || gameOver)
        {
            return;
        }
        
        currentLives--;
        Debug.Log("Lives left: " + currentLives);
        
        UpdateLivesUI();
        
        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            ResetBallToPaddle();
        }
    }

    void WinGame()
    {
        gameWon = true;

        Debug.Log("YOU WIN! Press R to Restart");
        
        if (winText != null)
        {
            winText.SetActive(true);
        }
        
        BallController ball = FindAnyObjectByType<BallController>();

        if (ball != null)
        {
            ball.StopBall();
        }
    }

    void GameOver()
    {
        gameOver = true;
        
        Debug.Log("GAME OVER! Press R to Restart");
        
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
        
        BallController ball = FindAnyObjectByType<BallController>();
        
        if (ball != null)
        {
            ball.StopBall();
        }
    }

    void ResetBallToPaddle()
    {
        BallController ball = FindAnyObjectByType<BallController>();
        
        if (ball != null)
        {
            ball.ResetBallToPaddle();
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

    void HideEndMessages()
    {
        if (winText != null)
        {
            winText.SetActive(false);
        }
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}