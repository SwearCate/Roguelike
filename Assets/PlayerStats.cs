using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public Text healthText;
    public Slider healthSlider;
    public Text collectedText;
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
        SetHealthUI();
    }

    void Update()
    {
        collectedText.text = "Items Collected" + collectedAmount;
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealthUI();
    }

    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
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
