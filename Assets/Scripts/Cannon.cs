using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject projeticlePrefab;

    [SerializeField] private float projectileForce;

    
    public void Fire()
    {
       var projetile = Instantiate(projeticlePrefab, firePoint.transform.position, firePoint.rotation);

        projetile.GetComponent<EnemyBullet>().rb2D.velocity = firePoint.right * projectileForce;
    }
}
