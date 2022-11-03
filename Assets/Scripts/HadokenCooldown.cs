using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class HadokenCooldown : MonoBehaviour
{
    [SerializeField] private Image imageCooldown;

    [SerializeField] private TMP_Text textCooldown;


    private bool isCooldown = false;
    private float cooldownTime = 6.0f;
    private float cooldownTimer = 0.0f;

    private void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    private void Update()
    {
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }

    public void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseSpell()
    {
        if(isCooldown)
        {
           // return false;
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            //return true;
        }
    }
}
