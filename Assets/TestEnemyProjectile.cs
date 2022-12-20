using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestEnemyProjectile : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            if (collision.GetComponent<Player>() != null)
            {
                collision.GetComponent<Player>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

}
