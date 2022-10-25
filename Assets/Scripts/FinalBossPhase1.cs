using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalBossPhase1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform[] moveSpots;

    [SerializeField] private float waitTime;

    [SerializeField] private float startWaitTime;

    [SerializeField] private int numberOfProjectiles;

    [SerializeField] private float projectileForce;

    [SerializeField] private GameObject finalBossProjectilePrefab;

    [SerializeField] private Transform firePoint;

    [SerializeField] private float radiusStart;
    [SerializeField] private float radiusEnd;

    [SerializeField] private Health health;

    [SerializeField] private Animator animator;

    [SerializeField] private float waitTimePerProjectile;

    [SerializeField] private float waitTimeWhenCircleIsOver;

    public bool stopShooting = false;

    
    private int randomSpot;

    private void Start()
    {
       
        StartCoroutine(FireProjectiles());

    }

    private void Update()
    {
        PlayerMovement();
        
    }

     public void PlayerMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private IEnumerator FireProjectiles()
    {
        while (stopShooting == false)
        {

            float angleStep = 360f / numberOfProjectiles;

            float angle = 0;

            for (int i = 0; i <= numberOfProjectiles; i++)
            {
                Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * firePoint.position * Random.Range(radiusStart, radiusEnd);

                animator.SetTrigger("attack02");

                GameObject bouncyProjectile = Instantiate(finalBossProjectilePrefab, firePoint.position, Quaternion.identity);

                bouncyProjectile.GetComponent<Rigidbody2D>().velocity = dir;

                Debug.Log("Bullet is instantieted");

                angle += angleStep;



                yield return new WaitForSeconds(waitTimePerProjectile);
            }

            yield return new WaitForSeconds(waitTimeWhenCircleIsOver);
        }

    }

}
