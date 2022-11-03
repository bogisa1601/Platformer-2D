using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBulletPhase2 : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;

    [SerializeField] private Transform player;

    [SerializeField] private Transform firePoint;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(firePoint.position, player.position, projectileSpeed * Time.deltaTime);
    }
}
