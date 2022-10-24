using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XerathHealth : Health
{
    [SerializeField] private ParticleSystem deathFX;

    [SerializeField] private ExitPortal exitPortal;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private XerathShooting xerathShooting;

    [SerializeField] private GameObject healthCanvas;



    public override void ModifyHealth(float amount)
    {
        CurrentHealth += amount;

        ConfigCurrentHealth();

        HealthSlider.value = CurrentHealth / MaxHealth;

        if (CurrentHealth <= 0)
        {
            spriteRenderer.enabled = false;
            healthCanvas.gameObject.SetActive(false);

            xerathShooting.StopShooting();

            deathFX.Play();
            exitPortal.gameObject.SetActive(true);
          

        }
    }
}
