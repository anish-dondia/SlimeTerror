using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] GameObject fireball;
    [SerializeField] Transform fire;

    bool isAlive = true;

    Rigidbody2D rb;
    Animator myAnimator;
    CapsuleCollider2D myCollider2D;
    BoxCollider2D myFeet;
    [SerializeField] AudioClip shootFireball;
     
    float gravityScaleAtStart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    void Update()
    {
        if(!isAlive) { return; }
        Run();
        Jump();
        Climbing();
        Death();
        ShootFireBall();
    }

    private void Death()
    {
        if(myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            rb.velocity = new Vector2(5f, 5f);
            FindObjectOfType<GameSession>().PlayerDeath();
        }
    }

    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        Vector2 PlayerVelocity = new Vector2(move * maxSpeed, rb.velocity.y);
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        rb.velocity = PlayerVelocity;

        if(move > 0)
        {
            Flip();
        }
        else 
        {
            Flip();
        }
    }

    void Climbing()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            myAnimator.SetBool("isClimbing", false);
            rb.gravityScale = gravityScaleAtStart;
            return;
        }

        float move = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rb.velocity.x, move * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }
    
    void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void ShootFireBall()
    {
        if(!isAlive) { return; }
        if(Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(shootFireball, transform.position); //had to go on project, audio and change DSP Buffer Size to Best Latency 
            Instantiate(fireball, fire.position, transform.rotation);
        }
    }
    
    private void Jump()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if(Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpHeight);
            rb.velocity += jumpVelocity;
        }
    }
}
