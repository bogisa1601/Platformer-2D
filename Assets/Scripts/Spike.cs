using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            player.Health -= damage;

            if (player.Health <= 0)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
