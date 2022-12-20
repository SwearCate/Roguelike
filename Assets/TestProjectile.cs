using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(collision.name == "Player" || collision.tag == "Projectile"))
        {
            if(collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            }
            if (collision.GetComponent<BossRecieveDamage>() != null)
            {
                collision.GetComponent<BossRecieveDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
