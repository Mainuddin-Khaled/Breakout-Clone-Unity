using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Game Settings")]
    public int startingLives = 3;
    private int remainingBricks;
    private int currentLives;
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
        Debug.Log("Bricks in level: " + remainingBricks);
        Debug.Log("Lives: " + currentLives);
    }

    public void BrickDestroyed()
    {
        if (gameWon || gameOver)
        {
            return;
        }

        remainingBricks--;

        Debug.Log("Remaining bricks: " + remainingBricks);

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

        Debug.Log("YOU WIN!");

        BallController ball = FindAnyObjectByType<BallController>();

        if (ball != null)
        {
            ball.StopBall();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("GAME OVER!");
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
}