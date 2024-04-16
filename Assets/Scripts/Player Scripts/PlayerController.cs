using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform groundCheck;

    private float _speed;
    private float lastDirection;
    private float direction;
    private float groundCheckRadius = 0.2f;
    private int airJumpCount = 0;

    [Header("Refrences")]
    public LayerMask groundLayer;

    [Header("Move Speeds")]
    public float speed = 10f;
    public float sprintSpeed = 20f;
    public float dashPower = 20f;

    [Header("Jump Settings")]
    public int maxJumpCount = 2;
    public float jumpPower = 16f;
    public float airJumpPower = 10f;

    [Header("Keybinds")]
    public KeyCode sprintKey =KeyCode.LeftControl;
    public KeyCode dashKey = KeyCode.LeftShift;


    void Start()
    {
        _speed = speed;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.GetChild(0);
    }


    void Update()
    {
        if (direction != 0)
        {
            lastDirection = direction;
        }
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);

        bool isGrounded = IsGrounded();

        Sprint(isGrounded);
        Jump(isGrounded);
        Dash(isGrounded, direction, lastDirection);
    }

    void Jump(bool isGrounded)
    {
        if (!isGrounded)
        {
            if (Input.GetButtonUp("Jump") && rb.velocity.y >= 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
    void Sprint(bool isGrounded)
    {
        if (!isGrounded)
        {
            speed = _speed;
            return;
        }
        if (Input.GetKey(sprintKey))
        {
            speed = sprintSpeed;
        }
        else speed = _speed;
    }
    // Dash? More like "blink" am I right? Ha Ha Ha!!!
    void Dash(bool isGrounded, float dir, float lastDir)
    {
        if (Input.GetKeyDown(dashKey) && dir != 0)
        {
            rb.velocity = new Vector2(dashPower * direction, rb.velocity.y);
        }
        else if (Input.GetKeyDown(dashKey))
        {
            rb.velocity = new Vector2(dashPower * lastDir, rb.velocity.y);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
