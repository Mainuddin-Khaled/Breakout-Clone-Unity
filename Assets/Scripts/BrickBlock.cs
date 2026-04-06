using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    [Header("Brick Settings")]
    public int hitPoints = 1;

    [Header("Brick Colors")]
    public Color fullHealthColor = Color.red;
    public Color mediumHealthColor = Color.yellow;
    public Color lowHealthColor = Color.green;

    private SpriteRenderer spriteRenderer;
    private int currentHitPoints;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;

        UpdateBrickColor();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeHit();
        }
    }

    void TakeHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            DestroyBrick();
        }
        else
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayBrickHit();
            }
            UpdateBrickColor();
        }
    }

    void DestroyBrick()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBrickBreak();
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BrickDestroyed();
        }

        Destroy(gameObject);
    }

    void UpdateBrickColor()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (hitPoints<= 1)
        {
            spriteRenderer.color = lowHealthColor;
            return;
        }

        if (hitPoints == 2)
        {
            if (currentHitPoints == 2)
            {
                spriteRenderer.color = fullHealthColor;
            }
            else
            {
                spriteRenderer.color = lowHealthColor;
            }
            return;
        }

        if (hitPoints >= 3)
        {
            if (currentHitPoints >= 3)
            {
                spriteRenderer.color = fullHealthColor;
            }
            else if (currentHitPoints == 2)
            {
                spriteRenderer.color = mediumHealthColor;
            }
            else
            {
                spriteRenderer.color = lowHealthColor;
            }
        }
    }
}