using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rb2D;
    [SerializeField] private int damage;
    
    void Start()
    {
        Destroy(gameObject,2.5f);
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.TryGetComponent(out PatrollingEnemy enemy))
        {
            enemy.Health -= damage;

            if (enemy.Health <= 0)
            {
                Destroy(enemy.gameObject);
            }

            Destroy(gameObject);
        }
        
        if (collision.gameObject.TryGetComponent(out Health mordeHealth))
        {
            mordeHealth.ModifyHealth(- damage);

           
            Destroy(gameObject);
            return;
        }

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        
        

        if (col.gameObject.TryGetComponent(out Health mordeHealth))
        {
            mordeHealth.ModifyHealth(-damage);

            if (mordeHealth.CurrentHealth <= 0)
            {
                Destroy(mordeHealth.gameObject);
            }

            Destroy(gameObject);
            return;
        }

        /*
                PatrollingEnemy enemy = col.gameObject.GetComponent<PatrollingEnemy>();

                if (enemy != null)
                {
                    enemy.Health -= damage;

                    if (enemy.Health <= 0)
                    {
                        Destroy(enemy.gameObject);
                    }
                }
        */


    }
    
    
}
