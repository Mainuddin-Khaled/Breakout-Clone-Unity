using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int remainingBricks;
    private bool gameWon = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        BrickBlock[] bricks = FindObjectsByType<BrickBlock>();
        remainingBricks = bricks.Length;

        Debug.Log("Bricks in level: " + remainingBricks);
    }

    public void BrickDestroyed()
    {
        if (gameWon)
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
}