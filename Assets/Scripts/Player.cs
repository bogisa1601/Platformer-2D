using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player : MonoBehaviour
{
    [field: SerializeField] public int Health { get; set; }
    
    
    //todo damage interface za playera 

    private void Start()
    {
        GameController.singleton.currentActivePlayer = this;

        if (!string.IsNullOrEmpty(SceneController.Singleton.lastSceneName) &&
            SceneController.Singleton.lastSceneName == SceneManager.GetActiveScene().name &&
            SceneController.Singleton.loadedPlayerPosition != Vector2.zero)
        {
            transform.position = SceneController.Singleton.loadedPlayerPosition;
        }
        
        SaveDataController.Singleton.SaveGame();
    }
}
