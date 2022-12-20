using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public static int collectedAmount = 0;


    public float health;
    public float maxHealth;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        health = maxHealth;
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();

    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    float CalculateHealthPercentage()
    {
        return health / maxHealth;
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
            Destroy(player);
        }
    }

}
