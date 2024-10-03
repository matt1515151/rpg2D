using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hookshot : MonoBehaviour
{
    public LayerMask groundLayer;
    public Shoot shoot;
    public bool isGrounded;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
            shoot.isShotActive = false;
            isGrounded = false;
        }
    }
}
