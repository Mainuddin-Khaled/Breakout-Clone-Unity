using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform paddle;
    public float launchSpeed = 8f;
    public Vector2 launchDirection = new Vector2(0.7f, 1f);
    public float maxBounceAngle = 60f;
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
        if (rigidBody.linearVelocity.sqrMagnitude > 0.01f)
        {
            rigidBody.linearVelocity = rigidBody.linearVelocity.normalized * launchSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            HandlePaddleBounce(collision);
        }
    }

    void HandlePaddleBounce(Collision2D collision)
    {
        float paddleX = paddle.position.x;
        float ballX = transform.position.x;
        float difference = ballX - paddleX;
        float halfPaddleWidth = collision.collider.bounds.size.x / 2f;
        float normalizedHit = difference / halfPaddleWidth;
        normalizedHit = Mathf.Clamp(normalizedHit, -1f, 1f);
        float bounceAngle = normalizedHit * maxBounceAngle;
        float angleInRadians = bounceAngle * Mathf.Deg2Rad;
        Vector2 newDirection = new Vector2(Mathf.Sin(angleInRadians), Mathf.Cos(angleInRadians));
        rigidBody.linearVelocity = newDirection.normalized * launchSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Debug.Log("Ball lost!");

            rigidBody.linearVelocity = Vector2.zero;

            transform.position = paddle.position + paddleOffset;

            hasLaunched = false;
        }
    }

    public void StopBall()
    {
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.angularVelocity = 0f;
        hasLaunched = true;
    }
}
