using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealth : Health
{

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject healthCanvas;

    [SerializeField] private ParticleSystem hitFx;

    public override void ModifyHealth(float amount)
    {
        CurrentHealth += amount;

        ConfigCurrentHealth();

        hitFx.Play();

        
        HealthSlider.value = CurrentHealth / MaxHealth;

        if (CurrentHealth <= 0)
        {
            spriteRenderer.enabled = false;

            healthCanvas.gameObject.SetActive(false);

        }

    }
}
