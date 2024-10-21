using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int bounceStrength = 30;
    bool movingRight = true;

    void FixedUpdate()
    {
        Vector2 moveAmount = new(moveSpeed * (movingRight ? 1 : -1), 0f);
        transform.position += (Vector3)moveAmount * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { 
            // turn around when hitting a wall
            movingRight = !movingRight;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().Bounce(bounceStrength,
                () => { GetComponent<Animator>().Play("bounce"); });
        }
    }
}
