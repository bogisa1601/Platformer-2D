using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] public int Damage { get; set; }

    [SerializeField] private BoxCollider2D wallCheckCollider;

    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private float moveSpeed;

    public int MaxHealth { get; private set; }

    private void Start()
    {
        MaxHealth = Health;
    }

    private void Update()
    {
        transform.Translate(transform.localScale.x * moveSpeed * Time.deltaTime,0,0);
        
        if (wallCheckCollider.IsTouchingLayers(groundLayer))
        {
            transform.localScale =
                new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            player.Health -= Damage;

            if (player.Health <= 0)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
