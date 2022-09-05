using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [field: SerializeField] public Slider HealthSlider { get; private set; }
    
    [field: SerializeField] public float MaxHealth { get; private set; }
    
    [field: SerializeField] public float LerpDuration { get; private set; }

    [field: SerializeField] public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        HealthSlider.value = CurrentHealth / MaxHealth;
    }
    
    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;

        ConfigCurrentHealth();

        //HealthSlider.value = _currentHealth / MaxHealth;

        LerpHealth(HealthSlider.value, CurrentHealth / MaxHealth);
        
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject,LerpDuration);
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
    
    private void ConfigCurrentHealth()
    {
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

    private void LerpHealth(float from, float to)
    {
        if (to <= 0)
        {
            to -= 0.1f;
        }
        
        StartCoroutine(LerpHealthInternal());

        IEnumerator LerpHealthInternal()
        {
            float timeElapsed = 0;
            
            while (timeElapsed < LerpDuration)
            {
                HealthSlider.value = Mathf.Lerp(from, to, timeElapsed / LerpDuration);

                if (from < to)
                {
                    CurrentHealth = HealthSlider.value * MaxHealth;
                }
                
                timeElapsed += Time.deltaTime;

                yield return null;
            }

            LerpHealth(HealthSlider.value, 1);
        }
    }





}
