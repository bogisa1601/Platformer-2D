using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : MonoBehaviour,IDestructible
{
    [SerializeField] private GameObject fxPrefab;


    public void DestroyAndPlayFx()
    {
        Destroy(gameObject);
        Instantiate(fxPrefab, null);
        
    }
}
