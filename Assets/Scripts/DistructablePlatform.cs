using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistructablePlatform : MonoBehaviour
{

    [SerializeField] private float aliveDuration;
    
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            Destroy(gameObject,aliveDuration);
        }
    }
}
