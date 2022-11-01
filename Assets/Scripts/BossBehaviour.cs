using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float damagePoint;
    public float maxDamage = 5;
    public float shootPeriod = 1;
    public float nextShot;

    public HealthBehaviourScript Healthbar;
    public GameObject bossBullet;

    void Start()
    {
        nextShot = Time.time;
        damagePoint = maxDamage;
        Healthbar.Health(damagePoint, maxDamage);
    }

    void Update()
    {
        FireRate();
    }

    public void FireRate()
    {
        if(Time.time >= nextShot)
        {
            Instantiate(bossBullet, transform.position + new Vector3(0,1f,0), Quaternion.identity);
            nextShot = Time.time + shootPeriod;
        }
    }

    public void TakeDamage(float damage)
    {
        damagePoint -= damage;
        Healthbar.Health(damagePoint, maxDamage);

        if(damagePoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
