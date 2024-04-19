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
    private bool isGrounded;
    private bool isJumping;
    private bool jumpRelease;
    private bool isSprinting;
    private bool isDashing;

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

    private void Update()
    {
        if (direction != 0)
        {
            lastDirection = direction;
        }
        isGrounded = IsGrounded();
        direction = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");
        jumpRelease = Input.GetButtonUp("Jump");
        isSprinting = Input.GetKey(sprintKey);
        Jump();
        Sprint();
        Dash();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    void Jump()
    {
        if (!isGrounded)
        {
            if (jumpRelease && rb.velocity.y >= 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            if (isJumping && airJumpCount < maxJumpCount)
            {
                rb.velocity = new Vector2(rb.velocity.x, airJumpPower);
                airJumpCount++;
            }
            return;
        }
        else
        {
            if (isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            airJumpCount = 0;
        }

    }
    void Sprint()
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
    void Dash()
    {
        if (Input.GetKeyDown(dashKey) && direction != 0)
        {
            rb.velocity = new Vector2(dashPower * direction, rb.velocity.y);
        }
        else if (Input.GetKeyDown(dashKey))
        {
            rb.velocity = new Vector2(dashPower * lastDirection, rb.velocity.y);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
