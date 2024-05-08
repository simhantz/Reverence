using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public bool isMoving;

    [Header("References")]
    [SerializeField] private LayerMask _groundLayer;

    [Header("Move Speeds")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _sprintSpeed = 20f;
    [SerializeField] private float _dashPower = 20f;

    [Header("Jump Settings")]
    [SerializeField] private int _maxJumpCount = 2;
    [SerializeField] private float _jumpPower = 16f;
    [SerializeField] private float _airJumpPower = 10f;

    [Header("Keybinds")]
    [SerializeField] private KeyCode _sprintKey =KeyCode.LeftControl;
    [SerializeField] private KeyCode _dashKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _attackKey = KeyCode.C;


    private Transform _groundCheck;
    private Animator _animator;

    private float _speedBackUp;
    private float _lastDirection;
    private float _direction;
    private float _groundCheckRadius = 0.2f;

    private int _airJumpCount = 0;

    private bool _isGrounded;
    private bool _isJumping;
    private bool _jumpRelease;
    private bool _isDashing;
    private bool _isSprinting;
    #endregion
    void Awake()
    {
        _speedBackUp = _speed;
        rb = GetComponent<Rigidbody2D>();
        _groundCheck = gameObject.transform.GetChild(0);
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Attack();

        // Ändrar lastDirection för dashen
        if (_direction != 0)
        {
            _lastDirection = _direction;
        }
        _isGrounded = IsGrounded();

        #region Inputs
        _direction = Input.GetAxisRaw("Horizontal");
        _isJumping = Input.GetButtonDown("Jump");
        _jumpRelease = Input.GetButtonUp("Jump");
        _isSprinting = Input.GetKey(_sprintKey);
        #endregion

        SpriteHandler();

        Jump();
        Sprint();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(_speed * _direction, rb.velocity.y);
    }
    private void OnDisable()
    {
        // Gör så att man står stilla när t.ex står i meny
        _direction = 0;
        _animator.SetBool("isMoving", false);
        rb.velocity = Vector3.zero;
    }

    #region Movement
    /// <summary>
    /// Gör så att spelaren hoppar
    /// </summary>
    void Jump()
    {
        // 
        if (!_isGrounded)
        {
            if (_jumpRelease && rb.velocity.y >= 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            if (_isJumping && _airJumpCount < _maxJumpCount)
            {
                rb.velocity = new Vector2(rb.velocity.x, _airJumpPower);
                _airJumpCount++;
            }
            return;
        }
        else
        {
            if (_isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpPower);
            }
            _airJumpCount = 0;
        }

    }
    /// <summary>
    /// Gör sår man springer... WOW!!!
    /// </summary>
    void Sprint()
    {
        // Om man inte är på marken så kan man inte sprinta
        if (!_isGrounded)
        {
            _speed = _speedBackUp;
            return;
        }

        // Om kan trycker sprint knappet kan man sprinta
        if (Input.GetKey(_sprintKey))
        {
            _speed = _sprintSpeed;
        }
        else _speed = _speedBackUp;
    }
    // Dash? More like "blink" am I right? Ha Ha Ha!!!
    // More like ass. Funkar inte. Lite skit måste skrivar om
    bool Dash()
    {
        if (Input.GetKeyDown(_dashKey))
        {
            // Dashes
            Debug.Log("You dashed!");
            rb.AddForce(new Vector2(_dashPower, rb.velocity.y));
            return true;
        }
        else return false;
    }

    /// <summary>
    /// Ritar en cirkel och kollar om den krockar med marken
    /// </summary>
    /// <returns>En bool om cirkelns krockar med marken</returns>
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
    #endregion

    void Attack()
    {
        if (Input.GetKeyDown(_attackKey))
        {
            _animator.SetBool("isAttacking", true);
        }
        if (Input.GetKeyDown(_attackKey) && AttackHandler.Attackable)
        {
            Debug.Log("Attack");
            AttackHandler.GrabbedEnemy.hp -= PlayerStatus.SlashDamage;
        }
    }

    public void SpriteHandler()
    {
        if (_direction != 0)
        {
            transform.localScale = new Vector3(_direction, 1, 1);
        }
        if (_direction == 0f)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);

        }
    }
}
