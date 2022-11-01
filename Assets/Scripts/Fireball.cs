using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float fireballSpeed = 10f;
    float fireSpeed;

    Rigidbody2D rb;
    PlayerController player;
    [SerializeField] AudioClip deathSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        fireSpeed = player.transform.localScale.x * fireballSpeed;
    }

    void Update()
    {
        rb.velocity = new Vector2(fireSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(deathSFX, transform.position);
            Debug.Log("dead");
        }

        if(other.tag == "Boss")
        {
            var enemy = other.GetComponent<BossBehaviour>();
            if (enemy)
            {
                enemy.TakeDamage(1); //hits for 1 damage
                AudioSource.PlayClipAtPoint(deathSFX, transform.position);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
