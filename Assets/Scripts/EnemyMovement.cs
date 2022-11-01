using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //new working script to keep
    public bool isMoving;
    [SerializeField] float movespeed = 2f;
    Rigidbody2D rb;
    
    void Start()
    {
        isMoving = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(movespeed, rb.velocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Flip();
    }

    void Flip()
    {
        isMoving = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        movespeed *= -1;
        isMoving = true;
    }
}
