using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBulletPortal : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject bouncyBulletPrefab;

    [SerializeField] private float bulletForce;

    [SerializeField] private int startNumberofBullets;
    [SerializeField] private int endNumberofBullets;

    [SerializeField] private float spawnDelay;

    [SerializeField] private Vector3 rotation;

    [SerializeField] private float rotationDuration;

    private void Start()
    {
        RotateFirePoint();   
    }


    private void OnEnable()
    {
        StartCoroutine(SpawnBullets());
    }

    public IEnumerator SpawnBullets()
    {
        int numeberOfBullets = Random.Range(startNumberofBullets, endNumberofBullets);

        for(int i = 0; i < numeberOfBullets; i++)
        {
            var bullet = Instantiate(bouncyBulletPrefab, firePoint.position, firePoint.rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletForce;

            yield return new WaitForSeconds(spawnDelay);
        }
        
        gameObject.SetActive(false);
    }

    private void RotateFirePoint()
    {
        firePoint.DORotate(rotation, rotationDuration).SetLoops(-1, LoopType.Yoyo);
    }
}
