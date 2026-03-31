using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float leftLimit = -7f;
    public float rightLimit = 7f;

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = Vector3.right * moveInput * moveSpeed * Time.deltaTime;
        transform.position += movement;
        float clampedX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
