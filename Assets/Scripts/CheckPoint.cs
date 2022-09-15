using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            SaveDataController.Singleton.SaveGame();
            _boxCollider2D.enabled = false;
        }
    }
}
