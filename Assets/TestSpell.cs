using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{

    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float fireDelay;
    private float lastFire;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
    /* Cтрельба по курсору
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);
        }
    */


        // Стрельба на стрелки
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * projectileForce, vertical * projectileForce, 0);

        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");

        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, shootVert);
            lastFire = Time.time;
        }

    }
    void Shoot(float x, float y)
    {
        GameObject spell = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        spell.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0 ) ? Mathf.Floor(x) * projectileForce : Mathf.Ceil(x) * projectileForce,
            (y < 0) ? Mathf.Floor(y) * projectileForce : Mathf.Ceil(y) * projectileForce,
            0
            );
    }
}
