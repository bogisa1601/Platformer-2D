using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpStrength;
    
    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private CapsuleCollider2D cc2D;
    [SerializeField] private BoxCollider2D groundCollider;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask climbingLayer;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private GameObject firePoint;
   
    private float dirX = 0;
    private float dirY = 0;

    [SerializeField] private float fireRate;
    private float nextFire;

    [SerializeField] private float climbingSpeed;

    private float _startingGravitySacale = 0;

    private void Start()
    {
        _startingGravitySacale = rb2D.gravityScale;
    }

    void Update()
    {
        Jump();
        FlipSprite();
        Fire();
    }

    private void FixedUpdate()
    {
        Move();
        Climb();
    }

    private void Move()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

        Animate();
        
        Vector2 velocity = new Vector2(dirX * moveSpeed * Time.fixedDeltaTime, rb2D.velocity.y);

        rb2D.velocity = velocity;

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && groundCollider.IsTouchingLayers(groundLayer))
        {
            Vector2 velocity = new Vector2(0, jumpStrength);

            rb2D.velocity += velocity;
        } 
    }

    private void Animate()
    {
        if (Mathf.Abs(dirX) > 0)
        {
            animator.SetBool("isRunning",true);
            return;
        }
        animator.SetBool("isRunning",false);
    }

    private void FlipSprite()
    {
        //|-2| = 2, apsolutna vrijednost je vazda pozitivna
        bool isPlayerMoving = Mathf.Abs(rb2D.velocity.x) > Mathf.Epsilon;

        if (isPlayerMoving)
        {
            //Mathf.Sign funkcija ukoliko je vrijednost 0 ili veca od 0 vrace pozitivan broj 1, u suprotnom -1 
            float scaleX = Mathf.Sign(rb2D.velocity.x);

            if (dirX == 0) return;
            
            transform.localScale = new Vector2(scaleX,transform.localScale.y);
        }
    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            
            animator.SetTrigger("fire");
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position,firePoint.transform.rotation);

            bullet.GetComponent<Bullet>().speed *= transform.localScale.x;
        }
    }

    private void Climb()
    {

        if (!cc2D.IsTouchingLayers(climbingLayer))
        {
            rb2D.gravityScale = _startingGravitySacale;
            return;
        }

        Vector2 climbVelocity = new Vector2(rb2D.velocity.x, dirY * climbingSpeed);

        rb2D.velocity = climbVelocity;

        rb2D.gravityScale = 0;
    }

}
