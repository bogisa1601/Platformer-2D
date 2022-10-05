using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    [field: SerializeField] public CollectibleData Data { get; set; }
    public abstract void Collect(Player player);

   
}
