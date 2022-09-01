using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [field: SerializeField] public Slider HealthSlider { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = MaxHealth;

        HealthSlider.value = _currentHealth / MaxHealth;
    }
    
    public void ModifyHealth(float amount)
    {
        _currentHealth += amount;

        ConfigCurrentHealth();

        HealthSlider.value = _currentHealth / MaxHealth;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void ConfigCurrentHealth()
    {
        if (_currentHealth >= MaxHealth)
        {
            _currentHealth = MaxHealth;
            return;
        }

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }
    

}
