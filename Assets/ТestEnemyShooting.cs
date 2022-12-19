using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ТestEnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    private Transform Player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public int cooldown;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (Player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = Player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }

    }

    private object WaitForSeconds(int cooldown)
    {
        throw new System.NotImplementedException();
    }
}
