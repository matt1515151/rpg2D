using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables to control movement speed
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    // Holds the player's input
    private Vector2 movement;

    void Update()
    {
        // Get the player's input (horizontal axis, A/D or Left/Right arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");

        // Optional: Flip the character's sprite when moving left or right
        if (movement.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip to the left
        }
        else if (movement.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Face to the right
        }

        if(Input.GetKey(KeyCode.Space))
        {
            movement.y = 10f;
        }
        else
        {
            movement.y = -6f;
        }
    }

    void FixedUpdate()
    {
        movement.x *= moveSpeed;
        // Apply movement to the Rigidbody2D
        rb.position = rb.position + movement * Time.fixedDeltaTime;

        if(rb.position.x < -12 )
        {
            rb.MovePosition(new Vector2(10, rb.position.y));
        }
        else if(rb.position.x > 12)
        {
            rb.MovePosition(new Vector2(-10, rb.position.y));
        }
    }
}
