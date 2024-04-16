using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform groundCheck;

    private float direction;
    private int airJumpCount = 0;

    public LayerMask groundLayer;

    public int maxJumpCount = 2;
    public float speed = 10f;
    public float jumpPower = 16f;
    public float airJumpPower = 10f;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.GetChild(0);
    }


    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        
        Jump(isGrounded());
    }

    void Jump(bool isGrounded)
    {
        if (!isGrounded)
        {
            if (Input.GetButtonUp("Jump") && rb.velocity.y >= 0f)
            {
                rb.velocity *= 0.5f;
            }
            if (Input.GetButtonDown("Jump") && airJumpCount < maxJumpCount)
            {
                rb.velocity = new Vector2(rb.velocity.x, airJumpPower);
                airJumpCount++;
            }
            return;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

            airJumpCount = 0;
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
