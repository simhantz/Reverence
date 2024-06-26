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

    [SerializeField] private Timer cooldown;


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
        _animator.SetBool("isAttacking", false);

        Attack();

        // �ndrar lastDirection f�r dashen
        if (_direction != 0)
        {
            _lastDirection = _direction;
        }
        _isGrounded = IsGrounded();

        _direction = Input.GetAxisRaw("Horizontal");
        _isJumping = Input.GetButtonDown("Jump");
        _jumpRelease = Input.GetButtonUp("Jump");
        _isSprinting = Input.GetKey(_sprintKey);

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
        // G�r s� att man st�r stilla n�r t.ex st�r i meny
        _direction = 0;
        _animator.SetBool("isMoving", false);
        rb.velocity = Vector3.zero;
    }

    #region Movement
    /// <summary>
    /// G�r s� att spelaren hoppar
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
    /// G�r s�r man springer... WOW!!!
    /// </summary>
    void Sprint()
    {
        // Om man inte �r p� marken s� kan man inte sprinta
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
    // More like ass. Funkar inte. Lite skit m�ste skrivar om
    //bool Dash()
    //{
    //    if (Input.GetKeyDown(_dashKey))
    //    {
    //        float ogGravity = rb.gravityScale;
    //        rb.gravityScale = 0;
    //        rb.velocity = new Vector3(_dashPower * _lastDirection, rb.velocity.y);
    //        rb.gravityScale = ogGravity;
    //        return true;
    //    }
    //    else return false;
    //}

    /// <summary>
    /// Ritar en cirkel och kollar om den krockar med marken
    /// </summary>
    /// <returns>En bool om cirkelns krockar med marken</returns>
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
    #endregion
    /// <summary>
    /// tar inputs f�r attack (som �r C)
    /// </summary>
    void Attack()
    {
        // Anv�nder Timer classens cooldown som jag gjort
        if (cooldown.CooldownFinished())
        {
            return;
        }
        // En bool i AttackHandler scriptet som �r static. Jag kollar om jag �r i range av en bandit
        if (Input.GetKeyDown(_attackKey) && AttackHandler.Attackable)
        {
            // Spelar animationen och skadar banditen
            Debug.Log("Attack");
            _animator.SetBool("isAttacking", true);
            AttackHandler.GrabbedEnemy.healthPoints -= PlayerStatus.SlashDamage;

            // s�tter den nya cooldownen
            cooldown.SetCooldown();
        }
        else if (Input.GetKeyDown(_attackKey))
        {
            // Annars om cooldownen �r klar men utan f�r range spelas bara animationen 
            _animator.SetBool("isAttacking", true);
        }
    }
    /// <summary>
    /// Hanterar spriten f�r spelaren och vrider och v�nder p� dens riktning
    /// Samt som att spela animationen
    /// </summary>
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
