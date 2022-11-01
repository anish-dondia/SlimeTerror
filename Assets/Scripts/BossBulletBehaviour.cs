using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBehaviour : MonoBehaviour
{
    float speed = 5f;

    //Rigidbody2D rb;
    Vector2 shotDirection;
    PlayerController player;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        shotDirection = (player.transform.position - transform.position).normalized * speed;
        //rb.velocity = new Vector2(shotDirection.x, shotDirection.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(shotDirection.x, shotDirection.y);
        Destroy(gameObject, 2.5f);
    }
}
