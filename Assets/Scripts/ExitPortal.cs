using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{

    [SerializeField] private string sceneName;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("build index: "+buildIndex);
            SceneManager.LoadScene("Level "+(SceneManager.GetActiveScene().buildIndex+2));
        }
    }
}
