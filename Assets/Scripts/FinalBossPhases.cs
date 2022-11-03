using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalBossPhases : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform[] moveSpots;

    [SerializeField] private float waitTime;
    [SerializeField] private float waitTimeForDashing;

    [SerializeField] private float startWaitTime;

    [SerializeField] private int numberOfProjectiles;

    [SerializeField] private float projectileForce;

    [SerializeField] private GameObject finalBossProjectilePrefab;

    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform phase2FirePoint;


    [SerializeField] private float radiusStart;
    [SerializeField] private float radiusEnd;

    [SerializeField] private Health health;

    [SerializeField] private Animator animator;

    [SerializeField] private float waitTimePerProjectile;

    [SerializeField] private float waitTimeWhenCircleIsOver;

    [SerializeField] private CircleCollider2D cc2d;

    [SerializeField] private Transform playerPhase2MoveToPosition;

    [SerializeField] private float moveToPositionSpeed;

    [SerializeField] private BoxCollider2D groundCheckCollider;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float dashSpeed;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private GameObject finalBoss;

    [SerializeField] private GameObject finalBossBulletPhase2;

    public bool stopShooting = false;

    public Vector3 positionToDashTo;

    public Vector3 positionToDashToPhase3;

    public bool isMoving = false;


    public bool canDash = true;

    public bool isGrounded = false;


    private int randomSpot;

    private float healthDivision = 3;

    private void Start()
    {
        StartCoroutine(FireProjectiles());

    }


    public void StopShooting()
    {
        stopShooting = true;
    }

    private void Update()
    {
        PlayerMovement();
        if (health.CurrentHealth <= (health.MaxHealth / healthDivision) * 2 && health.CurrentHealth > (health.MaxHealth / healthDivision))
        {
            Debug.Log("Phase 2 starting");
            MovePlayerTowardsPoint();

            if (transform.position == playerPhase2MoveToPosition.position)
            {
                StartCoroutine(DashPhase());
            }
        }

        if (health.CurrentHealth <= (health.MaxHealth / healthDivision))
        {
            Debug.Log("Phase 3 starting");
            StopCoroutine(DashPhase());
            StartCoroutine(Phase3());

        }

    }



    public void PlayerMovement()
    {
        if (health.CurrentHealth > (health.MaxHealth / healthDivision) * 2 && health.CurrentHealth > (health.MaxHealth / healthDivision))

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Random.Range(10f, 15f) * Time.deltaTime);


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

                if (stopShooting == true) yield break;

                yield return new WaitForSeconds(waitTimePerProjectile);
            }

            yield return new WaitForSeconds(waitTimeWhenCircleIsOver);
        }

    }

    private void MovePlayerTowardsPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[5].position, moveSpeed * Time.deltaTime);
    }


    private IEnumerator DashPhase()
    {
        animator.SetBool("walk", true);
        finalBoss.transform.DOMove(positionToDashTo, 75f * Time.deltaTime).SetLoops(1, LoopType.Yoyo).SetDelay(2f);

        if (transform.position == moveSpots[5].position || transform.position == positionToDashTo)
        {
            animator.SetBool("walk", false);
        }
        yield return null;
    }

    private IEnumerator Phase3()
    {
        MovePlayerTowardsPoint();
        if (transform.position == moveSpots[5].position)
        {
            transform.position = moveSpots[5].position;
            transform.position = Vector2.MoveTowards(transform.position, positionToDashToPhase3, 25f * Time.deltaTime);
        }
        if(transform.position == positionToDashToPhase3)
        {
            
            stopShooting = true;
            animator.SetTrigger("attack");
        }

        yield return null ;
    }

    
    
    
}


    



    

