using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Transform bossTargetToDashTo1;
    [SerializeField] private Transform bossTargetToDashTo2;

    [SerializeField] private float dashSpeed;

    [SerializeField] private Rigidbody2D rb2d;

    public bool stopShooting = false;

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
        if (health.CurrentHealth <= (health.MaxHealth / healthDivision) * 2)
        {
            MovePlayerTowardsPoint();
            stopShooting = true;
            while(health.CurrentHealth <= (health.MaxHealth / healthDivision) * 2)
            {
                StartCoroutine(Dash());
            }
        }

    }

   

    public void PlayerMovement()
    {
        if(health.CurrentHealth > (health.MaxHealth / healthDivision) * 2 && health.CurrentHealth > (health.MaxHealth / healthDivision))
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

                if(stopShooting == true) yield break;

                yield return new WaitForSeconds(waitTimePerProjectile);
            }

            yield return new WaitForSeconds(waitTimeWhenCircleIsOver);
        }

    }

    private void MovePlayerTowardsPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[5].position, moveSpeed * Time.deltaTime);
    }


    private IEnumerator Dash()
    {


        if (groundCheckCollider.IsTouchingLayers(groundLayer))
        {
            isGrounded = true;
            animator.SetBool("walk", true);
            transform.position = Vector2.MoveTowards(transform.position, bossTargetToDashTo1.position, dashSpeed * Time.deltaTime);

        }

        yield return new WaitForSeconds(2f);

        if(groundCheckCollider.IsTouchingLayers(groundLayer))
        {
            isGrounded = true;
              transform.position = Vector2.MoveTowards(transform.position, bossTargetToDashTo2.position, dashSpeed * Time.deltaTime);
        }

        
    }

    

    
}
