using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool canOpen = true;

    private Vector2 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player) && canOpen)
        {
            canOpen = false;
            transform.DOMove(new Vector3(transform.position.x, transform.position.y + 2), 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && canOpen)
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y + 2), 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            canOpen = false;
            transform.DOMove(startingPosition, 0.5f);
        }
    }
}
