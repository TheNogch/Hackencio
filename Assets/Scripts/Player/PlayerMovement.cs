using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    public float moveSpeed = 5;
    private float horizontalSpeed = 0.0f;
    
    public float jumpSpeed = 7;
    private bool isGrounded;

    public bool betterJump = true;

    public float fallMultiplier = 2.0f;
    public float lowJumpMultiplier = 1.0f;

    public bool canMove = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(horizontalSpeed * moveSpeed, rb.velocity.y);

            if (horizontalSpeed < 0)
            {
                animator.SetBool("Run", true);
                spriteRenderer.flipX = true;
            }
            else if (horizontalSpeed > 0)
            {
                animator.SetBool("Run", true);
                spriteRenderer.flipX = false;
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }

            if (isGrounded)
            {
                animator.SetBool("Jump", false);
            }
            else
            {
                animator.SetBool("Jump", true);
                animator.SetBool("Run", false);
            }

            if (betterJump)
            {
                if (rb.velocity.y < 0)
                {
                    rb.velocity += (fallMultiplier) * Time.deltaTime * Physics2D.gravity.y * Vector2.up;
                }
                if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
                {
                    rb.velocity += (lowJumpMultiplier) * Time.deltaTime * Physics2D.gravity.y * Vector2.up;
                }
            }
        }
    }
}
