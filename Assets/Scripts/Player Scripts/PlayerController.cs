using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float direction;
    private float heldTime;

    public float speed = 10f;
    public float jumpPower = 16f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity *= 0.5f;
        }
    }
}
