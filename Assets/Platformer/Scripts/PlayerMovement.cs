using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Shoot shoot;
    [Space]
    public float moveSpeed;
    public float jumpForce;
    public float swingSpeedMod, airSpeedMod, airFriction;

    bool grounded;
    public bool wasGrappling;
    float movement;

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (grounded)
        {
            wasGrappling = false;
        }
        GetComponent<SpriteRenderer>().flipX = shoot.pointToCursor.rotateTarget.x < 0;
    }

    void FixedUpdate()
    {
        if (shoot.isGrappling)
        {
            rb.velocity += new Vector2(movement * moveSpeed * swingSpeedMod, 0f);
        }
        else if (wasGrappling)
        {
            rb.velocity += new Vector2(movement * moveSpeed * airSpeedMod, 0f);
            rb.velocity *= airFriction;
        }
        else
        {
            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        }
    }
}
