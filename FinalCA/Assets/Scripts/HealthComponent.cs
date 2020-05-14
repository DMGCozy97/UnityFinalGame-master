using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float Health = 1.0f;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    
    public void Start()
    {
        Health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if(Health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return Health / maxHealth;
    }

    public void ApplyDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
            Destroy(gameObject);
    }
}