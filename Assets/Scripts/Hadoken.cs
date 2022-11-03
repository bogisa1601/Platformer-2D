using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadoken : MonoBehaviour
{
    [SerializeField] private GameObject hadokenPrefab;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject chargedProcjetile;

    [SerializeField] private float chargeSpeed;

    [SerializeField] private float chargeTime;

    [SerializeField] private float hadokenForce;

    [SerializeField] private float fireRate;

    [SerializeField] private float damage;

    [SerializeField] private HadokenCooldown hadokenCooldown;

    [SerializeField] private FinalBossHealth finalBossHealth;

    
    private float nextFire;

    private bool isCharging;

    private void Update()
    {
        if (Input.GetKey(KeyCode.H) && chargeTime < 2) ;
        {
            isCharging = true;
            if (isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {

            chargeTime = 0;
        }
        else if (Input.GetKeyUp(KeyCode.H) && chargeTime >= 2)
        {
            ReleaseCharge();
        }
    }

    private void ReleaseCharge()
    {
        hadokenCooldown.GetComponent<HadokenCooldown>().UseSpell();
        FireHadoken();
        Debug.Log("HAAADOKKKKENN");
        isCharging = false;
        chargeTime = 0;
    }

    private void FireHadoken()
    {
        GameObject hadokenobj = Instantiate(chargedProcjetile, firePoint.position, firePoint.transform.rotation);

        var hadoken = hadokenobj.GetComponent<Bullet>();

        hadoken.rb2D.velocity = firePoint.transform.right * (transform.localScale.x * hadokenForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FinalBossHealth health))
        {
            health.ModifyHealth(-damage);
        }

    } 
}
