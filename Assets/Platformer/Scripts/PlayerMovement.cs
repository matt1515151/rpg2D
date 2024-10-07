using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Shoot shoot;
    public GameObject hookshot;
    [Space]
    public float moveSpeed;
    public float jumpForce;
    public float pullForce = 1f;

    bool pulling;
    bool grounded;
    float movement;
    bool facingRight;
    Hookshot hookshotScript;

    private void Start()
    {
        hookshotScript = hookshot.GetComponent<Hookshot>();
    }

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
        if (Input.GetMouseButton(0) && hookshotScript.isGrounded)
        {
            pulling = true;
        }
        else
        {
            pulling = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);

        if (pulling)
        {
            Vector2 pull = hookshot.transform.position - new Vector3(transform.position.x, transform.position.y);
            rb.velocity += pull * pullForce / Mathf.Sqrt(pull.magnitude);
        }
    }
}
