using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform paddle;
    public float launchSpeed = 8f;
    public Vector2 launchDirection = new Vector2(0.7f, 1f);
    private Rigidbody2D rigidBody;
    private bool hasLaunched = false;
    private Vector3 paddleOffset;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        paddleOffset = transform.position - paddle.position;
    }

    void Update()
    {
        if (!hasLaunched)
        {
            transform.position = paddle.position + paddleOffset;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }else
        {
            KeepBallSpeedConstant();
        }
    }

    void LaunchBall()
    {
        hasLaunched = true;
        Vector2 direction = launchDirection.normalized;
        rigidBody.linearVelocity = direction * launchSpeed;
    }

    void KeepBallSpeedConstant()
    {
        rigidBody.linearVelocity = rigidBody.linearVelocity.normalized * launchSpeed;
    }
}
