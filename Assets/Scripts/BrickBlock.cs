using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Brick destroyed!");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.BrickDestroyed();
            }

            Destroy(gameObject);
        }
    }
}