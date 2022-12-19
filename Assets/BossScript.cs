using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    private GameObject Boss;
    public GameObject Portal;

    private void Start()
    {
        health = maxHealth;
        Boss = GameObject.Find("Boss");
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
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Instantiate(Portal, (Boss.transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
