using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBox : MonoBehaviour, IDestructible
{
    [SerializeField] private GameObject fxPrefab;


    public void DestroyAndPlayFx()
    {
        Destroy(gameObject);
        Instantiate(fxPrefab, null);
        Debug.Log("aaa");
    }
}
