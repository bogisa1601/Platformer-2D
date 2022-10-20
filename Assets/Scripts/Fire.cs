using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float randonDestroyFireStart;
    [SerializeField] private float randonDestroyFireEnd;
    void Start()
    {
        Destroy(gameObject, Random.Range(randonDestroyFireStart, randonDestroyFireEnd));
    }

    
}
