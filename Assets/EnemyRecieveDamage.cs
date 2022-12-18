using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRecieveDamage : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    public GameObject coin;
    private GameObject Player;

    private void Start()
    {
        health = maxHealth;
        Player = GameObject.Find("Player");
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Instantiate(coin, Player.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
