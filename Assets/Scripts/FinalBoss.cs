using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private float movespeed;
    private Player Player => GameController.singleton.currentActivePlayer;

    [field : SerializeField] public Health PlayerHealth { get; set; }

    private void Update()
    {
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        if (transform.position.x > Player.transform.position.x)
        {
            transform.localScale = Vector2.one;
            return;
        }
        transform.localScale = new Vector2(-1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Health playerHealth))
        {
            playerHealth.ModifyHealth(-damage);
        }

    }
}
