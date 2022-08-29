using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private int damage;
    
    public float speed;
    
    void Start()
    {
        //rb2D.velocity = new Vector2(speed, 0);
        rb2D.velocity = Vector2.right * speed;

        Destroy(gameObject,2.5f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }
        
/*
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.Health -= damage;

            if (enemy.Health <= 0)
            {
                Destroy(enemy.gameObject);
            }
        }
*/

        if (col.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Health -= damage;

            if (enemy.Health <= 0)
            {
                Destroy(enemy.gameObject);
            }
            
            Destroy(gameObject);
        }
    }
    
    
}
