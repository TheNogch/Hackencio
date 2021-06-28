using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject gameOverMenu;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0.0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0.0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player") && !collision.CompareTag("foreground"))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<PlayerMovement>().isHidden)
            {
                gameOverMenu.SetActive(true);
            }
        }
    }




}
